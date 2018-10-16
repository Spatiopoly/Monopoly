using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class JailCase : AbstractCase
    {
        public override void Land(Game game) { }

        public override Image GetBoardCaseImage(Game game)
        {
            return Properties.Resources.Prison;
        }

        public override string ToString()
            => "Prison de l'espace";
    }
}
