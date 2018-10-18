using Monopoly.Models.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Models.Cards
{
    /// <summary>
    /// Go to X case card
    /// </summary>
    abstract class AbstractAdvanceCard : AbstractCard
    {
        /// <summary>
        /// Name of the destination that will be shown on the card
        /// </summary>
        public abstract string GetDestinationName(Game game);

        /// <summary>
        /// Get the index of the case that the player should go to
        /// </summary>
        /// <param name="game">Game object</param>
        /// <returns>Case index</returns>
        public abstract int GetCaseIndex(Game game);

        /// <summary>
        /// Rule that will be shown
        /// </summary>
        public virtual string Rule
            => "Recevez F200 si vous passez par la case départ.";

        /// <summary>
        /// Play the card
        /// </summary>
        /// <param name="game"></param>
        public override void Play(Game game)
        {
            int caseIndex = GetCaseIndex(game);

            game.PlayDice(game.ResultFirstDice, game.ResultSecDice);
        }

        public override string GetContent(Game game)
        {
            return $"Allez jusqu'à {GetDestinationName(game)}. {Rule}.";
        }
    }
}
