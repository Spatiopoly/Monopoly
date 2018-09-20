using Monopoly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.Views
{
    public partial class frmPlayerChoice : Form
    {
        List<PlayerSelector> lstPlayersSelector;
        List<Player> lstPlayers;

        public frmPlayerChoice()
        {
            InitializeComponent();

            lstPlayersSelector = new List<PlayerSelector>()
            {
                selectorPlayerRed,
                selectorPlayerYellow,
                selectorPlayerPurple,
                selectorPlayerGreen,
                selectorPlayerBlue
            };
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            lstPlayers = new List<Player>();

            // Bug dans l'affichage des message box
            foreach (PlayerSelector ps in lstPlayersSelector)
            {
                if (ps.IsActive)
                {
                        Player player = new Player(ps.Color, ps.PlayerName);
                        lstPlayers.Add(player);

                }
            }

            if (lstPlayers.Count < 2)
            {
                MessageBox.Show("Il faut au moins 2 joueurs");
            }
            else if (lstPlayers.Exists(p => p.Name == ""))
            {
                MessageBox.Show("Vous devez entrez un nom de joueur pour chaque joueur actif");
            }
            else
            {
                Game game = new Game(lstPlayers);
                Form frmGame = new frmGame(game);
                frmGame.Show();
                this.Close();
            }
        }
    }
}
