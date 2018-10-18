using System.Collections.Generic;
using System.Linq;
using Monopoly.Models.Cases;

namespace Monopoly.Models
{
    public class Player
    {
        // Event : show a textual message on the interface
        public event CurrentCaseChangedHandler CurrentCaseChanged;
        public delegate void CurrentCaseChangedHandler(Player player, int oldCaseIndex, int newCaseIndex);

        /// <summary>
        /// All the colors that a player can have. Each color is linked to an avatar.
        /// </summary>
        public enum PlayerColor { Purple, Yellow, Green, Red, Blue }

        /// <summary>
        /// Create a new Player instance
        /// </summary>
        /// <param name="color">PlayerColor</param>
        /// <param name="name">Displayed name of the player</param>
        public Player(PlayerColor color, string name)
        {
            Color = color;
            Name = name;
        }

        /// <summary>
        /// Current amount of money owned by the player
        /// </summary>
        public int Wealth { get; set; } = 1500;

        public int LastFirstDiceResult { get; set; } = 0;

        public int LastSecDiceReslut { get; set; } = 0;

        public int NbDoubles { get; set; } = 0;

        public bool IsInJail { get; set; } = false;

        /// <summary>
        /// Number of jail exit cards owned by the player
        /// </summary>
        public int JailExitCardsCount { get; set; } = 0;

        /// <summary>
        /// Index of the case where the player currently is
        /// </summary>
        public int CurrentCaseIndex { get; private set; } = 0;

        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Color of the player
        /// </summary>
        public PlayerColor Color { get; private set; }

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

        /// <summary>
        /// Change the current case index
        /// </summary>
        /// <param name="newCaseIndex">The index of the new case</param>
        public void GoToCase(int newCaseIndex)
        {
            int oldCaseIndex = CurrentCaseIndex;
            CurrentCaseIndex = newCaseIndex;
            CurrentCaseChanged?.Invoke(this, oldCaseIndex, newCaseIndex);
        }
    }
}
