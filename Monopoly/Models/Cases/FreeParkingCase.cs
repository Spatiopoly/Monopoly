using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class FreeParkingCase : AbstractCase
    {
        public override void Land(Game game)
        {
            throw new NotImplementedException();
        }

        public override Image GetBoardCaseImage()
        {
            return Properties.Resources.Parc;
        }
    }
}
