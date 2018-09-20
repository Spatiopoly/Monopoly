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
        }

        /// <summary>
        /// Handle the change of the current player
        /// </summary>
        /// <param name="game"></param>
        private void Game_NextPlayer(Game game)
        {
            primaryColor.Set(game.CurrentPlayer.Color.GetColor());

            // Load the propertie
            flpProperties.Controls.Clear();
            var cases = game.CurrentPlayer.GetProperties(game);
            foreach (PropertyCase c in cases)
            {
                flpProperties.Controls.Add(new PropertyManager()
                {
                    Property = c
                });
            }
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
            tmrLancerDes.Enabled = true;
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
                tmrLancerDes.Enabled = false;
                compteurImageDes = 0;
                
                resultSecDice = rnd.Next(1, 7);

                pbxDe1.BackgroundImage = diceImages[resultFirstDice];
                pbxDe2.BackgroundImage = diceImages[resultSecDice];

                // Envoyer le resultat des dé aux pions pour qu'il puissent avancer
            }
            compteurImageDes++;
        }
    }
}
