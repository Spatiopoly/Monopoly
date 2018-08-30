using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cards
{
    /// <summary>
    /// "Chance" / "Community Chest" card
    /// </summary>
    public abstract class AbstractCard
    {
        /// <summary>
        /// What happens when a player gets the card?
        /// </summary>
        /// <param name="game">The game status</param>
        public abstract void Play(Game game); 
    }
}
