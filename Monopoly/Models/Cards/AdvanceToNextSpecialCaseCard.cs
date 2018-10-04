using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cards
{
    /// <summary>
    /// Advance to the next station or the next utility case
    /// </summary>
    class AdvanceToNextSpecialCaseCard : AbstractAdvanceCard
    {
        public enum SpecialCaseType { Station, Utility }

        public SpecialCaseType Type { get; private set; }
        CardType deck;

        public AdvanceToNextSpecialCaseCard(SpecialCaseType type, CardType cardType)
        {
            Type = type;
            deck = cardType;
        }

        public override CardType Deck => deck;

        public override string GetDestinationName(Game game)
            => Type == SpecialCaseType.Station
            ? "la prochaine gare"
            : "le prochain service";

        public override int GetCaseIndex(Game game)
        {
            List<int> caseIndexes;

            if (Type == SpecialCaseType.Station)
                caseIndexes = new List<int> { 5, 15, 25, 35 };
            else
                caseIndexes = new List<int> { 12, 28 };

            // Take the greater case index after our current position
            int caseIndex = caseIndexes.Where(i => i >= game.CurrentPlayer.CurrentCaseIndex)
                .FirstOrDefault();

            // If there are no cases available after our position, take the first one
            if (caseIndex == default(int))
                caseIndex = caseIndexes[0];

            return caseIndex;
        }

        public override string Rule => Type == SpecialCaseType.Station
                                        ? "Payez 2x le loyer habituel"
                                        : "Lancer le dé et payez 10x le nombre lancé";
    }
}
