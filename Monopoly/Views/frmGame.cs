﻿using Monopoly.Models;
using Monopoly.Models.Cards;
using Monopoly.Models.Cases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Monopoly.Views
{
    public partial class frmGame : Form
    {
        public Game game;
        int compteurImageDes;
        int resultFirstDice = 0;
        int resultSecDice = 0;
        public TabControl sideTabs;

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

            sideTabs = tabs;
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


                game.ResultFirstDice = resultFirstDice;
                game.ResultSecDice = resultSecDice;

                tmrDice.Enabled = true;

            }

            compteurImageDes++;
        }

        public void UpdateTabs()
        {
            Player currentPlayer = game.CurrentPlayer;
            AbstractCase currentCase = game.Cases[game.CurrentPlayer.CurrentCaseIndex];

            tabs.TabPages.Clear();

            if (!game.HasPlayed && currentPlayer.NbDoubles <= 0) // @TODO : Player hasn't played ( firt throw )
            {
                btnLancerDes.Enabled = true;

                tabs.TabPages.Add(tabCaseDes);
            }
            else 
            {
                if (currentPlayer.NbDoubles > 0)
                {
                    btnLancerDes.Enabled = true;

                    tabs.TabPages.Add(tabCaseDes);
                }
                if (currentCase is StartCase || currentCase is FreeParkingCase || currentCase is GoToJailCase || currentCase is JailCase)
                {

                    string title = currentCase.ToString();

                    if (currentCase is StartCase)
                    {
                        title += Environment.NewLine + "Vous gagnez 200F";
                    }
                    else if (currentCase is JailCase)
                    {
                        if (currentPlayer.IsInJail == true)
                        {
                            title += Environment.NewLine + "En prison !";
                        }
                        else
                        {
                            title += Environment.NewLine + "Visite simple";
                        }                        
                    }
                    else if (currentCase is GoToJailCase)
                    {
                        title += Environment.NewLine + "Allez en prison !";
                    }

                    lblCaseCoin.Text = title;

                    pbxCaseCoin.BackgroundImage = currentCase.GetBoardCaseImage(game);
                    pbxCaseCoin.BackgroundImageLayout = ImageLayout.Zoom;
                    
                    tabs.TabPages.Add(tabCaseCoin);
                }
                else if (currentCase is TaxCase)
                {
                    TaxCase taxe = currentCase as TaxCase;
                    pbxCaseTaxeCarte.BackgroundImage = taxe.GetBoardCaseImage(game);
                    tabs.TabPages.Add(tabCaseTaxe);
                }
                else if (currentCase is CardCase)
                {
                    CardCase specialCard = currentCase as CardCase;

                    lblChanceChancellerie.Text = game.LastSpecialCard.ToString();
                    pbxCaseChanceImage.BackgroundImage = specialCard.TypeImage;
                    lblCaseChanceChancelTitre.Text = specialCard.ToString();


                    tabs.TabPages.Add(tabCaseChanceChancel);
                }
                else if (currentCase is PropertyCase)
                {
                    PropertyCase property = currentCase as PropertyCase;

                    if (property.Owner == currentPlayer || property.Owner != null)
                    {
                        if (property.Owner == currentPlayer)
                        {
                            lblCasePropAchetee.Text = $"Bienvenue chez vous, {currentPlayer.Name} !";
                        }
                        else
                        {
                            if (!property.IsMortgaged)
                            {
                                lblCasePropAchetee.Text = $"Vous êtes chez {property.Owner.Name}.{Environment.NewLine}Vous payez {property.GetRent(game)}F de loyer";
                            } else
                            {
                                lblCasePropAchetee.Text = $"Propriété hypothéquée {Environment.NewLine} Vous ne payez rien";
                            }
                            
                        }

                        pbxCasePropAchetee.BackgroundImage = property.GetPropertyCardImage(2);

                        tabs.TabPages.Add(tabCasePropAchetee);
                    }
                    else
                    {
                        if (currentPlayer.Wealth >= property.Price)
                        {
                            btnAcheterPropriete.Enabled = true;
                            pbxCasePropSimple.BackgroundImage = property.GetPropertyCardImage(2);
                            lblCasePropSimplePrixAchat.Text = "Prix d'achat :" + Environment.NewLine + $"{property.Price}F";
                            tabs.TabPages.Add(tabCasePropSimple);
                        }
                        else
                        {
                            pbxCasePropSimple.BackgroundImage = property.GetPropertyCardImage(2);
                            lblCasePropSimplePrixAchat.Text = "Vous n'avez pas assez de Flouzz.";
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
                PropertyManager pm = new PropertyManager()
                {
                    Property = c,
                    Game = game,
                    FrmGame = this,
                };

                flpProperties.Controls.Add(pm);

                pm.UpdateBuildings();
            }
            tabs.TabPages.Add(tabProperties);
        }

        private void tmrDice_Tick(object sender, EventArgs e)
        {
            tmrDice.Enabled = false;

            // Envoyer le resultat des deux dés aux pions pour qu'il puissent avancer
            game.PlayDice(resultFirstDice, resultSecDice);
            UpdateTabs();
        }

        private void btnAcheterPropriete_Click(object sender, EventArgs e)
        {
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
                        property.Invalidate();
                    }
                }         
            }

            btnAcheterPropriete.Enabled = false;
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

        /// <summary>
        /// Permet de debug en choisissant des valeurs => A enlever a la fin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDebug_Click(object sender, EventArgs e)
        {
            frmCheat debug = new frmCheat(this);
            debug.Show();
        }
    }
}
