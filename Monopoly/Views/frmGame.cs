using Monopoly.Models;
using Monopoly.Models.Cases;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Monopoly.Views
{
    public partial class frmGame : Form
    {
        ColorProperty primaryColor = new ColorProperty(Color.Silver, 2, TransitionTimingFunction.EaseInOut);
        Game game = new Game();

        public frmGame()
        {
            InitializeComponent();

            gameView.Game = game;
            gameView.PrimaryColor = primaryColor;

            game.CurrentPlayerChanged += Game_CurrentPlayerChanged;

            game.Start();
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
