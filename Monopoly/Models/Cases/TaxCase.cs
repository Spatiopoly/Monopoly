using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class TaxCase : AbstractCase
    {
        public enum Tax { IncomeTax = 100, LuxuryTax = 1000 }

        public Tax Type { get; private set; }

        public int Amount
            => (int)Type;

        public TaxCase(Tax type)
        {
            Type = type;
        }

        public override void Land(Game game) { }
    }
}
