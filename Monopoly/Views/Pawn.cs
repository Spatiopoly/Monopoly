using Monopoly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Views
{
    /// <summary>
    /// Display a pawn on the board
    /// </summary>
    class Pawn
    {
        private Player player;

        public NumberProperty Position { get; } = new NumberProperty(0);

        /// <summary>
        /// Create a new pawn with a player
        /// </summary>
        /// <param name="player"></param>
        public Pawn(Player player)
        {
            this.player = player;
        }
    }
}
