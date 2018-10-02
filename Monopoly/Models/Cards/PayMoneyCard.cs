using Monopoly.Models.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cards
{
    class PayMoneyCard : AbstractCard
    {
        private CardType _type;

        public override CardType Type
            => _type;

        public string Reason { get; private set; }

        public int Amount { get; private set; }

        public PayMoneyCard(string reason, int amount, CardType type)
        {
            Reason = reason;
            Amount = amount;
            _type = type;
        }

        // Cette methode est a tester pour voir si elle marche
        public override void Play(Game game)
        {
            const int MONTANT_PRESIDENCE = 50;
            const int MONTANT_MAISON = 25;
            const int MONTANT_HOTEL = 100;
            int montantTotal = 0;

            // Permet de gerer le cas ou le montant est multiplié par le nombre de maison et hotel
            if (Amount == -1)
            {
                foreach (PropertyCase p in game.CurrentPlayer.GetProperties(game))
                {
                    if (p is StreetProperty)
                    {
                        if ((p as StreetProperty).BuildingCount >= 5)
                        {
                            montantTotal += ((p as StreetProperty).BuildingCount - 1) * MONTANT_MAISON;
                            montantTotal += MONTANT_HOTEL;
                        }
                        else
                        {
                            montantTotal += (p as StreetProperty).BuildingCount * MONTANT_MAISON;
                        }
                    }
                }

                Amount = montantTotal;
                game.CurrentPlayer.Wealth -= Amount;
            }
            else if (Amount == -2)
            {
                game.CurrentPlayer.Wealth -= (game.Players.Count-1) * MONTANT_PRESIDENCE;

                foreach (Player p in game.Players)
                {
                    if (p != game.CurrentPlayer)
                    {
                        p.Wealth += MONTANT_PRESIDENCE;
                    }
                }
            }
            else
            {
                game.CurrentPlayer.Wealth -= Amount;
            }
            
        }

        public override string ToString()
            => $"{Reason}. Payez F{Amount}.";
    }
}
