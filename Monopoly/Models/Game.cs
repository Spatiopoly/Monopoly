using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Models.Cases;
using Monopoly.Models.Cards;

namespace Monopoly.Models
{
    public class Game
    {
        private int _currentPlayerIndex = 0;

        #region Properties

        /// <summary>
        /// List of participants in the game
        /// </summary>
        public List<Player> Players { get; private set; }

        /// <summary>
        /// The players who currently plays
        /// </summary>
        public Player CurrentPlayer
            => Players[_currentPlayerIndex];

        /// <summary>
        /// Cases on the board (properties...)
        /// </summary>
        public List<AbstractCase> Cases { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<AbstractCard> Cards { get; private set; }
		#endregion

        /// <summary>
        /// Initialize a new game
        /// </summary>
		public Game() 
		{

        }

    }
}
