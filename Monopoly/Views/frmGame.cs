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
            }

            compteurImageDes++;
        }

        public void UpdateTabs()
        {
            Player currentPlayer = game.CurrentPlayer;
            currentPlayer.CurrentCaseIndex = 1;
            AbstractCase currentCase = game.Cases[game.CurrentPlayer.CurrentCaseIndex];

            tabs.TabPages.Clear();
            tabs.TabPages.Add(tabCaseDes);

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
                pbxCaseTaxeCarte.BackgroundImageLayout = ImageLayout.Zoom;
                tabs.TabPages.Add(tabCaseTaxe);
            }
            else if (currentCase is CardCase)
            {
                CardCase specialCard = currentCase as CardCase;

                if (specialCard.Type == CardType.Chance)
                {
                    lblCaseChanceChancelTitre.Text = "Chance";
                    flpCouleur.BackColor = Color.Green;
                    pbxCaseChanceImage.BackgroundImage = Properties.Resources.Luck;
                }
                else
                {
                    lblCaseChanceChancelTitre.Text = "Chancellerie";
                    pbxCaseChanceImage.BackgroundImage = Properties.Resources.CommunityChest;
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
                        tabCasePropAchetee.Text = "Votre Propriété";
                        lblCasePropAchetee.Text = "Bienvenue chez vous " + currentPlayer.Name + " !";
                    }
                    else
                    {
                        tabCasePropAchetee.Text = "Chez " + property.Owner.Name;
                        lblCasePropAchetee.Text = "Vous êtes chez " + property.Owner.Name + Environment.NewLine + "Vous payez " + property.GetRent() + " F de loyer";
                    }

                    pbxCasePropAchetee.BackgroundImage = property.GetPropertyCardImage();
                    pbxCasePropAchetee.BackgroundImageLayout = ImageLayout.Zoom;

                    tabs.TabPages.Add(tabCasePropAchetee);
                }
                else
                {
                    pbxCasePropSimple.BackgroundImage = property.GetPropertyCardImage();
                    pbxCasePropSimple.BackgroundImageLayout = ImageLayout.Zoom;

                    tabCasePropSimple.Text = "Achat Propriété";
                    lblCasePropSimplePrixAchat.Text = "Prix d'achat :" + Environment.NewLine + property.Price + " F";
                    tabs.TabPages.Add(tabCasePropSimple);
                }
            }

            tabs.TabPages.Add(tabProperties);
        }

        private void tmrDice_Tick(object sender, EventArgs e)
        {
            // Envoyer le resultat des dé aux pions pour qu'il puissent avancer
            tmrDice.Enabled = false;
        }

        private void btnAcheterPropriete_Click(object sender, EventArgs e)
        {
            // @TODO
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
