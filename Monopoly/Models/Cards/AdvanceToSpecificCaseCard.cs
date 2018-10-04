using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cards
{
    /// <summary>
    /// Advance to a specific case on the board
    /// </summary>
    class AdvanceToSpecificCaseCard : AbstractAdvanceCard
    {
        CardType deck;
        private int _caseIndex;

        public AdvanceToSpecificCaseCard(int caseIndex, CardType typeCard)
        {
            _caseIndex = caseIndex;
            deck = typeCard;
        }

        public override CardType Deck => deck;

        public override int GetCaseIndex(Game game)
            => _caseIndex;

        public override string GetDestinationName(Game game)
        {
            return game.Cases[_caseIndex].ToString();
        }
    }
}
