using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models
{
    public class Player
    {
        public int Wealth { get; set; } = 1500;

        public int CurrentCaseIndex { get; set; } = 0;

        public int JailExitCardsCount { get; set; } = 0;

        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }
}
