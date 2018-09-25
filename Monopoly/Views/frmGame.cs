using Monopoly.Models;
using Monopoly.Models.Cases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoly.Views
{
    public partial class frmGame : Form
    {
        Game game;
        int compteurImageDes;
        int diceSum = 0;
        bool BuyingTurn = false;
        ColorProperty primaryColor = new ColorProperty(Color.Silver, 2, TransitionTimingFunction.EaseInOut);

        Random rnd = new Random();

        Dictionary<int, Image> diceImages = new Dictionary<int, Image>() {
            { 1, Properties.Resources.de1 },
            { 2, Properties.Resources.de2 },
            { 3, Properties.Resources.de3 },
            { 4, Properties.Resources.de4 },
            { 5, Properties.Resources.de5 },
            { 6, Properties.Resources.de6 },
        };

        Dictionary<Player.PlayerColor, Image> nextPlayerImages = new Dictionary<Player.PlayerColor, Image>() {
            { Player.PlayerColor.Blue, Properties.Resources.Next_Blue },
            { Player.PlayerColor.Yellow, Properties.Resources.Next_Yellow },
            { Player.PlayerColor.Red, Properties.Resources.Next_Red },
            { Player.PlayerColor.Green, Properties.Resources.Next_Green },
            { Player.PlayerColor.Purple, Properties.Resources.Next_Purple },
        };

        public frmGame(Game game)
        {
            InitializeComponent();
            this.game = game;

            gameView.Game = game;
            gameView.PrimaryColor = primaryColor;

            game.CurrentPlayerChanged += Game_CurrentPlayerChanged;

            game.Start();

            foreach (TabPage tp in new TabPage[] { tabCaseChanceChancel, tabCaseCoin, tabCasePropAchetee, tabCasePropSimple, tabCaseTaxe })
            {
                tp.Name = "Case actuelle";
            }
        }

        /// <summary>
        /// Handle the change of the current player
        /// </summary>
        /// <param name="game"></param>
        private void Game_CurrentPlayerChanged(Game game)
        {
            primaryColor.Set(game.CurrentPlayer.Color.GetColor());

            Player nextPlayer = game.Players[game.CurrentPlayerIndex == game.Players.Count - 1 ? 0 : game.CurrentPlayerIndex + 1];
            btnNextPlayer.Image = nextPlayerImages[nextPlayer.Color];

            UpdateTabs();
        }

        /// <summary>
        /// Refresh the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            gameView.Invalidate();
            tlpSidebar.BackColor = primaryColor.DisplayedValue;
        }

        private void btnLancerDes_Click(object sender, EventArgs e)
        {
            btnLancerDes.Enabled = false;
            tmrDiceAnimation.Enabled = true;
        }

        private void tmrLancerDes_Tick(object sender, EventArgs e)
        {
            int resultFirstDice = 0;
            int resultSecDice = 0;
            int indexImageFirstDice = rnd.Next(1, 7);
            pbxDe1.BackgroundImage = diceImages[indexImageFirstDice];

            int indexImageSecDice = rnd.Next(1, 7);
            pbxDe2.BackgroundImage = diceImages[indexImageSecDice];

            

            if (compteurImageDes == 10)
            {
                resultFirstDice = rnd.Next(1, 7);
                tmrDiceAnimation.Enabled = false;
                compteurImageDes = 0;

                resultSecDice = rnd.Next(1, 7);

                pbxDe1.BackgroundImage = diceImages[resultFirstDice];
                pbxDe2.BackgroundImage = diceImages[resultSecDice];

                tmrDice.Enabled = true;

                diceSum = resultFirstDice + resultSecDice;
            }

            compteurImageDes++;
        }

        public void UpdateTabs()
        {
            Player currentPlayer = game.CurrentPlayer;
            int oldCaseIndex = currentPlayer.OldCaseIndex;
            AbstractCase currentCase = game.Cases[game.CurrentPlayer.CurrentCaseIndex];

            tabs.TabPages.Clear();

            if (currentPlayer.CurrentCaseIndex == 0 && !BuyingTurn || currentPlayer.CurrentCaseIndex == oldCaseIndex && !BuyingTurn) // @TODO : Player hasn't played
            {
                btnLancerDes.Enabled = true;

                tabs.TabPages.Add(tabCaseDes);
            }
            else
            {
                if (currentCase is StartCase || currentCase is FreeParkingCase || currentCase is GoToJailCase || currentCase is JailCase)
                {
                    if (currentCase is StartCase)
                    {
                        lblCaseCoin.Text = "Case départ" + Environment.NewLine + "Vous gagnez 200F";
                    }
                    else if (currentCase is FreeParkingCase)
                    {
                        lblCaseCoin.Text = "Pause temporelle";
                    }
                    else if (currentCase is GoToJailCase)
                    {
                        lblCaseCoin.Text = "En allez prison !";
                    }
                    else
                    {
                        // Si il est en prison :
                        lblCaseCoin.Text = "Vous êtes prisonnier";
                        // Si il est en visite :
                        lblCaseCoin.Text = "Visite de la prison";
                    }

                    pbxCaseCoin.BackgroundImage = currentCase.GetBoardCaseImage();
                    pbxCaseCoin.BackgroundImageLayout = ImageLayout.Zoom;
                    
                    tabs.TabPages.Add(tabCaseCoin);
                }
                else if (currentCase is TaxCase)
                {
                    TaxCase taxe = currentCase as TaxCase;
                    pbxCaseTaxeCarte.BackgroundImage = taxe.GetBoardCaseImage();
                    tabs.TabPages.Add(tabCaseTaxe);
                }
                else if (currentCase is CardCase)
                {
                    CardCase specialCard = currentCase as CardCase;

                    if (specialCard.Type == CardType.Chance)
                    {
                        lblCaseChanceChancelTitre.Text = "Chance";
                        flpCouleur.BackColor = Color.Green;
                        pbxCaseChanceImage.BackgroundImage = specialCard.GetBoardCaseImage();
                    }
                    else
                    {
                        lblCaseChanceChancelTitre.Text = "Chancellerie";
                        pbxCaseChanceImage.BackgroundImage = specialCard.GetBoardCaseImage();
                        flpCouleur.BackColor = Color.Red;
                    }

                    lblCaseChanceChancel.Text = specialCard.Type == CardType.Chance ? "Chance" : "Chancellerie";

                    tabs.TabPages.Add(tabCaseChanceChancel);
                }
                else if (currentCase is PropertyCase)
                {
                    PropertyCase property = currentCase as PropertyCase;

                    if (property.Owner == currentPlayer || property.Owner != null)
                    {
                        if (property.Owner == currentPlayer)
                        {
                            lblCasePropAchetee.Text = "Bienvenue chez vous " + currentPlayer.Name + " !";
                        }
                        else
                        {
                            lblCasePropAchetee.Text = "Vous êtes chez " + property.Owner.Name + Environment.NewLine + "Vous payez " + property.GetRent() + " F de loyer";
                        }

                        pbxCasePropAchetee.BackgroundImage = property.GetPropertyCardImage();

                        tabs.TabPages.Add(tabCasePropAchetee);
                    }
                    else
                    {
                        if (currentPlayer.Wealth >= property.Price)
                        {
                            btnAcheterPropriete.Enabled = true;
                            pbxCasePropSimple.BackgroundImage = property.GetPropertyCardImage();
                            lblCasePropSimplePrixAchat.Text = "Prix d'achat :" + Environment.NewLine + property.Price + " F";
                            tabs.TabPages.Add(tabCasePropSimple);
                        }
                        else
                        {
                            pbxCasePropSimple.BackgroundImage = property.GetPropertyCardImage();
                            lblCasePropSimplePrixAchat.Text = "vous n'avez pas assez de Flouzz pour acheter";
                            btnAcheterPropriete.Enabled = false;
                            tabs.TabPages.Add(tabCasePropSimple);
                        }
                    }
                }
            }


            // Load the properties
            flpProperties.Controls.Clear();
            var cases = game.CurrentPlayer.GetProperties(game);
            foreach (PropertyCase c in cases)
            {
                flpProperties.Controls.Add(new PropertyManager()
                {
                    Property = c
                });
            }
            tabs.TabPages.Add(tabProperties);

            BuyingTurn = false;
        }

        private void tmrDice_Tick(object sender, EventArgs e)
        {
            // Envoyer le resultat des dés aux pions pour qu'il puissent avancer
            game.PlayDice(diceSum);
            tmrDice.Enabled = false;
            UpdateTabs();
        }

        private void btnAcheterPropriete_Click(object sender, EventArgs e)
        {
            //@TODO affichage en direct des achats dans propriétés pour le moment attente d'un tour nescessaire...
            Player currentPlayer = game.CurrentPlayer;
            AbstractCase currentCase = game.Cases[game.CurrentPlayer.CurrentCaseIndex];
                                 
            if (currentCase is PropertyCase)
            {
                PropertyCase property = currentCase as PropertyCase;

                if (property.Owner == null)
                {
                    if (currentPlayer.Wealth >= property.Price)
                    {
                        currentPlayer.Wealth = currentPlayer.Wealth - property.Price;
                        property.Owner = currentPlayer;
                    }
                }         
            }

            btnAcheterPropriete.Enabled = false;
            BuyingTurn = true;
            UpdateTabs();
        }

        /// <summary>
        /// Click on the "next player" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPlayer_Click(object sender, EventArgs e)
        {       
            game.NextPlayer();
        }
    }
}
