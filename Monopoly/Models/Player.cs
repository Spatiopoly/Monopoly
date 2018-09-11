using System.Collections.Generic;
using System.Linq;
using Monopoly.Models.Cases;

namespace Monopoly.Models
{
    public class Player
    {
        public enum PlayerColor { Purple, Yellow, Green, Red, Blue }

        public int Wealth { get; set; } = 1500;

        public int CurrentCaseIndex { get; set; } = 0;

        public int JailExitCardsCount { get; set; } = 0;

        public string Name { get; set; }

        public PlayerColor Color { get; private set; }

        public Player(PlayerColor color, string name)
        {
            Color = color;
            Name = name;
        }

        /// <summary>
        /// Get all the properties of a player
        /// </summary>
        /// <param name="game">The game instance</param>
        /// <returns>All the properties owned by the player</returns>
        internal List<PropertyCase> GetProperties(Game game)
        {
            return game.Cases
                .Where(c => c is PropertyCase)
                .Select(c => c as PropertyCase)
                .Where(p => p.Owner == this)
                .ToList();
        }
    }
}
