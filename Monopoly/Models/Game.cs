using Monopoly.Models.Cards;
using Monopoly.Models.Cases;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Monopoly.Models
{
    public class Game
    {
        // Event : show a textual message on the interface
        public event MessageHandler Message;
        public delegate void MessageHandler(Game game, string message);

        // Event : change the current player
        public event CurrentPlayerChangedHandler CurrentPlayerChanged;
        public delegate void CurrentPlayerChangedHandler(Game game);

        #region Properties

        /// <summary>
        /// List of participants in the game
        /// </summary>
        public List<Player> Players { get; private set; }

        public int CurrentPlayerIndex { get; private set; } = 0;

        /// <summary>
        /// The player who currently plays
        /// </summary>
        public Player CurrentPlayer
            => Players[CurrentPlayerIndex];

        /// <summary>
        /// Cases on the board (properties...)
        /// </summary>
        public List<AbstractCase> Cases { get; private set; }

        /// <summary>
        /// All the cards (chance/community chest) that are remaining
        /// </summary>
        public List<AbstractCard> Cards { get; private set; }

        /// <summary>
        /// Know if the current player has played on the current turn (= rolled the dice)
        /// </summary>
        public bool HasPlayed { get; private set; } = false;

        /// <summary>
        /// The last sum of the dices played
        /// </summary>
        public int LastDiceSum { get; private set; }
        #endregion

        /// <summary>
        /// Initialize a new game
        /// </summary>
        public Game(List<Player> players)
        {
            Players = players;

            Cases = new List<AbstractCase>() {
                new StartCase(),

                new StreetProperty(PropertyColor.DarkPurple, "Mediterranean Avenue", 60, 50, new int[] { 2, 10, 30, 90, 160, 250 }),
                new CardCase(CardType.CommunityChest),
                new StreetProperty(PropertyColor.DarkPurple, "Baltic Avenue", 60, 50, new int[] { 4, 20, 60, 180, 320, 450 }),
                new TaxCase(TaxCase.Tax.IncomeTax),
                new StationProperty("Reading Railroad"),
                new StreetProperty(PropertyColor.LightBlue, "Oriental Avenue", 100, 50, new int[] { 6, 30, 90, 270, 400, 550 }),
                new CardCase(CardType.Chance),
                new StreetProperty(PropertyColor.LightBlue, "Vermont Avenue", 100, 50, new int[] { 6, 30, 90, 270, 400, 550 }),
                new StreetProperty(PropertyColor.LightBlue, "Connecticut Avenue", 120, 50, new int[] { 8, 40, 100, 300, 450, 600 }),

                new JailCase(),
                new StreetProperty(PropertyColor.Pink, "St. Charles Place", 140, 100, new int[] { 10, 50, 150, 450, 625, 750 }),
                new UtilityProperty("Nuclear Energy Company"),
                new StreetProperty(PropertyColor.Pink, "States Avenue", 140, 100, new int[] { 10, 50, 150, 450, 625, 750 }),
                new StreetProperty(PropertyColor.Pink, "Virginia Avenue", 160, 100, new int[] { 12, 60, 180, 500, 700, 900 }),
                new StationProperty("Pennsylvania Railroad"),
                new StreetProperty(PropertyColor.Orange, "St. James Place", 180, 100, new int[] { 14, 70, 200, 550, 750, 950 }),
                new CardCase(CardType.CommunityChest),
                new StreetProperty(PropertyColor.Orange, "Tennessee Avenue", 180, 100, new int[] { 14, 70, 200, 550, 750, 950 }),
                new StreetProperty(PropertyColor.Orange, "New York Avenue", 200, 100, new int[] { 16, 80, 220, 600, 800, 1000 }),

                new FreeParkingCase(),
                new StreetProperty(PropertyColor.Red, "Kentucky Avenue", 220, 150, new int[] { 18, 90, 250, 700, 875, 1050 }),
                new CardCase(CardType.Chance),
                new StreetProperty(PropertyColor.Red, "Indiana Avenue", 220, 150, new int[] { 18, 90, 250, 700, 875, 1050 }),
                new StreetProperty(PropertyColor.Red, "Illinois Avenue", 240, 150, new int[] { 20, 100, 300, 750, 925, 1100 }),
                new StationProperty("B. & O. Railroad"),
                new StreetProperty(PropertyColor.Yellow, "Atlantic Avenue", 260, 150, new int[] { 22, 110, 330, 800, 975, 1150 }),
                new StreetProperty(PropertyColor.Yellow, "Ventnor Avenue", 260, 150, new int[] { 22, 110, 330, 800, 975, 1150 }),
                new UtilityProperty("Water Delivery"),
                new StreetProperty(PropertyColor.Yellow, "Marvin Gardens", 280, 150, new int[] { 24, 120, 360, 850, 1025, 1200 }),


                new GoToJailCase(),
                new StreetProperty(PropertyColor.Green, "Pacific Avenue", 300, 200, new int[] { 26, 130, 390, 900, 1100, 1275 }),
                new StreetProperty(PropertyColor.Green, "North Carolina Avenue", 300, 200, new int[] { 26, 130, 390, 900, 1100, 1275 }),
                new CardCase(CardType.CommunityChest),
                new StreetProperty(PropertyColor.Green, "Pennsylvania Avenue", 320, 200, new int[] { 28, 150, 450, 1000, 1200, 1400 }),
                new StationProperty("Short Line"),
                new CardCase(CardType.Chance),
                new StreetProperty(PropertyColor.DarkBlue, "Park Place", 350, 200, new int[] { 35, 175, 500, 1100, 1300, 1500 }),
                new TaxCase(TaxCase.Tax.LuxuryTax),
                new StreetProperty(PropertyColor.DarkBlue, "Boardwalk", 400, 200, new int[] { 50, 200, 600, 1400, 1700, 2000 }),
            };
        }

        /// <summary>
        /// Start the game
        /// </summary>
        public void Start()
        {
            CurrentPlayerChanged(this);
        }

        public void SendMessage(string message)
        {
            Message?.Invoke(this, message);
        }

        /// <summary>
        /// Go to the next player
        /// </summary>
        public void NextPlayer()
        {
            // Update the current player
            CurrentPlayerIndex = CurrentPlayerIndex >= Players.Count - 1
                ? 0
                : CurrentPlayerIndex + 1;

            // Reset the turn variables
            HasPlayed = false;

            // Notify the view
            SendMessage("C'est au tour de " + CurrentPlayer.Name);
            CurrentPlayerChanged(this);
        }

        /// <summary>
        /// Play the dice result
        /// </summary>
        /// <param name="diceSum">Sum of the two dices</param>
        public void PlayDice(int diceSum)
        {
            LastDiceSum = diceSum;

            int oldCaseIndex = CurrentPlayer.CurrentCaseIndex;
            int newCaseIndex = (oldCaseIndex + diceSum) % Cases.Count;

            // Fly over intermediate case
            for (int i = oldCaseIndex + 1; i < oldCaseIndex + diceSum; i++)
            {
                Cases[i % Cases.Count].FlyOver(this);
            }

            // Land on the new case
            CurrentPlayer.GoToCase(newCaseIndex);
            Cases[CurrentPlayer.CurrentCaseIndex].Land(this);

            if (diceSum == 12)
            {              
                SendMessage("Le joueur " + CurrentPlayer.Name + " peut rejouer :3");

                if (MessageBox.Show("Voulez-vous rejouer ?", "rejouer ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    HasPlayed = false; // the player can replayed
                    SendMessage("Le joueur " + CurrentPlayer.Name + " a choisi de rejouer");
                }
                else
                {
                    SendMessage("Le joueur " + CurrentPlayer.Name + " a choisi de ne pas rejouer");
                    HasPlayed = true;
                }
            }
            else
            {
                HasPlayed = true;
            }
        }
    }
}
