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
        public override Image GetBoardCaseImage()
        {
            return Properties.Resources.Parc;
        }

        public override string ToString()
            => "Pause temporelle";
    }
}
