using Monopoly.Models.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cards
{
    class GoToPrisonCard : AbstractAdvanceCard
    {
        const int INDEX_CASE_ALLER_PRISON = 30;
        CardType deck;
        private int _caseIndex;

        public GoToPrisonCard(CardType typeCard)
        {
            _caseIndex = INDEX_CASE_ALLER_PRISON;
            deck = typeCard;
        }

        public override CardType Deck => deck;

        public override int GetCaseIndex(Game game)
            => _caseIndex;

        public override void Play(Game game)
        {
            

            if (game.CurrentPlayer.CurrentCaseIndex > INDEX_CASE_ALLER_PRISON)
            {
                game.CurrentPlayer.Wealth -= StartCase.SALARY_AMOUNT;
            }

            // @TODO: Changer la propriété "EnPrison" du joueur, mettre a true

            base.Play(game);
        }

        public override string GetDestinationName(Game game)
        {
            return game.Cases[_caseIndex].ToString();
        }
    }
}
