using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cards
{
    class AdvanceToStartCaseCard : AbstractAdvanceCard
    {
        CardType deck;

        public AdvanceToStartCaseCard(CardType typeCard)
        {
            deck = typeCard;
        }

        public override CardType Deck => deck;

        public override string Rule =>
            "Recevez F200";

        public override int GetCaseIndex(Game game)
            => 0;

        public override string GetDestinationName(Game game)
            => "la case Départ";
    }
}
