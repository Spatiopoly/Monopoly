using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    public abstract class AbstractCase
    {
        /// <summary>
        /// What happens when a player lands on the case?
        /// </summary>
        /// <param name="game">The game status</param>
        public abstract void Land(Game game);

        /// <summary>
        /// What happens when a players pass through the case?
        /// </summary>
        /// <param name="game">The game status</param>
        public virtual void FlyOver(Game game) {}
    }
}