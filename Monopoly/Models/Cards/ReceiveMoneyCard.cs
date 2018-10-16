using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cards
{
    class ReceiveMoneyCard : AbstractCard
    {
        public enum ReceiveMoneyCardType { Normale, Recolte }

        private ReceiveMoneyCardType typeReception;

        private CardType _type;

        public override CardType Deck 
            => _type;

        public string Reason { get; private set; }
        public int Amount { get; private set; }

        public ReceiveMoneyCard(string reason, int amount, ReceiveMoneyCardType typeReceiveMoneyCard ,CardType type)
        {
            Reason = reason;
            Amount = amount;
            _type = type;
            typeReception = typeReceiveMoneyCard;
        }

        public override void Play(Game game)
        {
            if (typeReception == ReceiveMoneyCardType.Normale)
            {
                game.CurrentPlayer.Wealth += Amount;
            }
            else if (typeReception == ReceiveMoneyCardType.Recolte)
            {
                foreach (Player p in game.Players)
                {
                    if (p != game.CurrentPlayer)
                    {
                        p.Wealth -= Amount;
                    }
                }

                game.CurrentPlayer.Wealth += Amount * (game.Players.Count() - 1);
            }
        }

        public override string GetContent(Game game)
        {
            string s = (typeReception == ReceiveMoneyCardType.Recolte) ? " de chaque joueur." : "";
            return $"{Reason}." + Environment.NewLine + $"Recevez F{Amount}" + s;
            //=> $"{Reason}. Vous recevez F{Amount}.";
        }


        public override string ToString()
        {
            string s = (typeReception == ReceiveMoneyCardType.Recolte) ? " de chaque joueur." : "";
            return $"{Reason}." + Environment.NewLine + $"Recevez F{Amount}" + s;
        }
    }
}
