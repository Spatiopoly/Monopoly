using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cards
{
    class ReceiveMoneyCard : AbstractCard
    {
        private CardType _type;

        public override CardType Type 
            => _type;

        public string Reason { get; private set; }
        public int Amount { get; private set; }

        public ReceiveMoneyCard(string reason, int amount, CardType type)
        {
            Reason = reason;
            Amount = amount;
            _type = type;
        }

        public override void Play(Game game)
        {
            game.CurrentPlayer.Wealth += Amount;
        }

        public override string ToString()
            => $"{Reason}. Recevez F{Amount}.";
    }
}
