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

            game.NextPlayer += Game_NextPlayer;

            game.Start();

            foreach (TabPage tp in new TabPage[] { tabCaseChanceChancel, tabCaseCoin, tabCasePropAchetee, tabCasePropSimple, tabCaseTaxe })
                tp.Name = "Case actuelle";
        }

        /// <summary>
        /// Handle the change of the current player
        /// </summary>
        /// <param name="game"></param>
        private void Game_NextPlayer(Game game)
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
                foreach (Control c in tableLayoutPanel9.Controls)
                {
                    if (c.Name == "lblCaseCoin")
                    {
                        if (currentCase is StartCase)
                        {
                            c.Text = "Case Start" + Environment.NewLine + "Vous Gagner 200 F";
                        }
                        else if (currentCase is FreeParkingCase)
                        {
                            c.Text = "Pause Temporelle";
                        }
                        else if (currentCase is GoToJailCase)
                        {
                            c.Text = "Aller en Prison!!!";
                        }
                        else
                        {
                            // Si il est en prison :
                            c.Text = "Vous êtes prisonnier";
                            // Si il est en visite :
                            c.Text = "Visite de la prison";
                        }
                    }

                    pbxCaseCoin.BackgroundImage = currentCase.GetBoardCaseImage();
                    pbxCaseCoin.BackgroundImageLayout = ImageLayout.Zoom;
                }

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

                foreach (Control c in tableLayoutPanel7.Controls)
                {
                    if (specialCard.Type == CardType.Chance)
                    {

                        if (c.Name == "lblCaseChanceChancelTitre")
                        {
                            c.Text = "Chance";
                        }

                        if (c.Name == "flpCouleur")
                        {
                            c.BackColor = Color.Green;
                        }

                        Control[] ctrlsPbx = tableLayoutPanel7.Controls.Find("pbxCaseChanceImage", true);
                        // Mettre image trefle:
                        //ctrlsPbx[0].BackgroundImage = Properties.Resources.
                    }
                    else
                    {
                        if (c.Name == "lblCaseChanceChancelTitre")
                        {
                            c.Text = "Chancellerie";
                        }

                        Control[] ctrlsPbx = tableLayoutPanel7.Controls.Find("pbxCaseChanceImage", true);
                        // Mettre image Coffre:
                        //ctrlsPbx[0].BackgroundImage = Properties.Resources.

                        Control[] ctrls = flowLayoutPanel2.Controls.Find("flpCouleur", true);
                        ctrls[0].BackColor = Color.Red;
                    }

                    if (c.Name == "lblCaseChanceChancel")
                    {
                        //c.Text = Mettre le texte de la carte Chance ou Chancellerie
                    }
                }

                tabs.TabPages.Add(tabCaseChanceChancel);
            }
            else if (currentCase is PropertyCase)
            {
                PropertyCase property = currentCase as PropertyCase;

                if (property.Owner == currentPlayer || property.Owner != null)
                {
                    foreach (Control c in tableLayoutPanel6.Controls)
                    {
                        if (property.Owner == currentPlayer)
                        {
                            if (c.Name == "lblCasePropAchetee")
                            {
                                tabCasePropAchetee.Text = "Votre Propriété";
                                c.Text = "Bienvenue chez vous " + currentPlayer.Name + " !";
                            }
                        }
                        else
                        {
                            if (c.Name == "lblCasePropAchetee")
                            {
                                tabCasePropAchetee.Text = "Chez " + property.Owner.Name;
                                c.Text = "Vous êtes chez " + property.Owner.Name + Environment.NewLine + "Vous payez " + property.GetRent() + " F de loyer";
                            }
                        }

                        pbxCasePropAchetee.BackgroundImage = property.GetPropertyCardImage();
                        pbxCasePropAchetee.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    
                    tabs.TabPages.Add(tabCasePropAchetee);
                }
                else
                {
                    pbxCasePropSimple.BackgroundImage = property.GetPropertyCardImage();
                    pbxCasePropSimple.BackgroundImageLayout = ImageLayout.Zoom;

                    tabCasePropSimple.Text = "Achat Propriété";
                    Control[] crtls = tableLayoutPanel5.Controls.Find("lblCasePropSimplePrixAchat", true);
                    crtls[0].Text = "Prix d'achat :" + Environment.NewLine + property.Price + " F";
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
    }
}
