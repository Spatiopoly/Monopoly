using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cases
{
    class CardCase : AbstractCase
    {
        public CardType Type { get; private set; }

        public CardCase(CardType type)
        {
            Type = type;
        }

        public override void Land(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
