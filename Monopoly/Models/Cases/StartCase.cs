using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class StartCase : AbstractCase
    {
        const int SALARY_AMOUNT = 200;

        public override void Land(Game game) {}

        public override void FlyOver(Game game)
        {
            game.CurrentPlayer.Wealth += SALARY_AMOUNT;
        }
    }
}
