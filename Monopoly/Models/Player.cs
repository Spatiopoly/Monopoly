using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
