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
        public override void Land(Game game) { }

        public override Image GetBoardCaseImage()
        {
            return Properties.Resources.EnAllez;
        }
    }
}
