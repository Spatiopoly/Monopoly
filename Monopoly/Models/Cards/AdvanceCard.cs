using Monopoly.Models.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cards
{
    class AdvanceCard : AbstractCard
    {
        private CardType _type;
        public override CardType Type
            => _type;
        public string NameDestination { get; private set; }
        public int IndexDestination { get; private set; }
        public string Rule { get; private set; }

        public AdvanceCard(string nameDestination, int indexDestination, string rule, CardType type)
        {
            NameDestination = nameDestination;
            IndexDestination = indexDestination;
            Rule = rule;
            _type = type;
        }

        public override void Play(Game game)
        {
            const int INDEX_SERVICE1 = 12;
            const int INDEX_SERVICE2 = 28;
            const int INDEX_GARE1 = 5;
            const int INDEX_GARE2 = 15;
            const int INDEX_GARE3 = 25;
            const int INDEX_GARE4 = 35;
            const int INDEX_PRISON = 10;

            // Permet de différencier les 2 utilities
            if (IndexDestination == -1)
            {
                if (game.CurrentPlayer.CurrentCaseIndex <= INDEX_SERVICE1)
                {
                    IndexDestination = INDEX_SERVICE1;
                }
                else if (game.CurrentPlayer.CurrentCaseIndex <= INDEX_SERVICE2)
                {
                    IndexDestination = INDEX_SERVICE2;
                }
                else
                {
                    IndexDestination = INDEX_SERVICE1;
                }
            }
            // Permet de différencier les gares
            else if (IndexDestination == -2)
            {
                if (game.CurrentPlayer.CurrentCaseIndex <= INDEX_GARE1)
                {
                    IndexDestination = INDEX_GARE1;
                }
                else if (game.CurrentPlayer.CurrentCaseIndex <= INDEX_GARE2)
                {
                    IndexDestination = INDEX_GARE2;
                }
                else if (game.CurrentPlayer.CurrentCaseIndex <= INDEX_GARE3)
                {
                    IndexDestination = INDEX_GARE3;
                }
                else if (game.CurrentPlayer.CurrentCaseIndex <= INDEX_GARE4)
                {
                    IndexDestination = 35;
                }
                else
                {
                    IndexDestination = INDEX_GARE1;
                }
            }

            if (IndexDestination == -3)
            {
                if (game.CurrentPlayer.CurrentCaseIndex > INDEX_PRISON)
                {
                    // Soustrait les 200 gagné si passage par la case départ
                    game.CurrentPlayer.Wealth -= 200;
                }

                IndexDestination = INDEX_PRISON;
                // TODO:: Mettre la propriété du joueur "EnPrison" à true
            }

            if (game.CurrentPlayer.CurrentCaseIndex < IndexDestination)
            {
                game.PlayDice(IndexDestination - game.CurrentPlayer.CurrentCaseIndex);
            }
            else
            {
                game.PlayDice(game.Cases.Count - game.CurrentPlayer.CurrentCaseIndex);  // Go à la case start
                game.PlayDice(IndexDestination); // Ensuite envoi sur la case demandee
            }
        }

        public override string ToString()
        {
            return "Allez jusqu'à " + NameDestination + " " + Environment.NewLine + Rule;
        }
    }
}
