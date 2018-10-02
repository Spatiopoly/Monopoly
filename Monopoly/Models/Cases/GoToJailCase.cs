using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class GoToJailCase : AbstractCase
    {
        private const int GO_TO_JAIL_CASE_INDEX = 30;
        private const int JAIL_CASE_INDEX = 10;

        public override void Land(Game game)
        {
            Player currentPlayer = game.CurrentPlayer;
            currentPlayer.isPrisonner = true;
            game.SendMessage($"{currentPlayer.Name} se fait capturer et va en prison !");
            

            if (currentPlayer.isPrisonner)
            {
                currentPlayer.GoToCase(JAIL_CASE_INDEX);
            }

        }

        public override Image GetBoardCaseImage()
        {
            return Properties.Resources.EnAllez;
        }

        public override string ToString()
            => "En allez prison !";
    }
}
