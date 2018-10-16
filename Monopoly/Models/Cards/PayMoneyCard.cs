using Monopoly.Models.Cases;
using System;

namespace Monopoly.Models.Cards
{
    class PayMoneyCard : AbstractCard
    {
        

        public enum PayMoneyCardType { Normale, Presidence, Reparations}

        private PayMoneyCardType typePaiement;

        private CardType _type;

        public override CardType Deck
            => _type;

        public string Reason { get; private set; }

        public int Amount { get; private set; }

        public PayMoneyCard(string reason, int amount, CardType type, PayMoneyCardType typePayMoneyCard)
        {
            Reason = reason;
            Amount = amount;
            _type = type;
            typePaiement = typePayMoneyCard;
        }

        // Cette methode est a tester pour voir si elle marche
        public override void Play(Game game)
        {
            const int MONTANT_PRESIDENCE = 50;
            const int MONTANT_MAISON_REPARATIONS = 25;
            const int MONTANT_HOTEL_REPARATIONS = 100;
            int montantTotal = 0;

            // Permet de gerer le cas ou le montant est multiplié par le nombre de maison et hotel
            if (typePaiement == PayMoneyCardType.Reparations)
            {
                foreach (PropertyCase p in game.CurrentPlayer.GetProperties(game))
                {
                    if (p is StreetProperty)
                    {
                        if ((p as StreetProperty).BuildingCount >= 5)
                        {
                            montantTotal += ((p as StreetProperty).BuildingCount - 1) * MONTANT_MAISON_REPARATIONS;
                            montantTotal += MONTANT_HOTEL_REPARATIONS;
                        }
                        else
                        {
                            montantTotal += (p as StreetProperty).BuildingCount * MONTANT_MAISON_REPARATIONS;
                        }
                    }
                }

                Amount = montantTotal;
                game.CurrentPlayer.Wealth -= Amount;
            }
            else if (typePaiement == PayMoneyCardType.Presidence)
            {
                Amount = MONTANT_PRESIDENCE;
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

        public override string GetContent(Game game)
        {
            string s = (typePaiement == PayMoneyCardType.Presidence) ? " à chaque joueur." : "";
            return $"{Reason}." + Environment.NewLine + $"Payez F{Amount}" + s;
            //=> $"{Reason}. Payez F{Amount}.";
        }


        public override string ToString()
        {
            string s = (typePaiement == PayMoneyCardType.Presidence) ? " à chaque joueur." : "";
            return $"{Reason}."+ Environment.NewLine + $"Payez F{Amount}" + s;
        }
    }
}
