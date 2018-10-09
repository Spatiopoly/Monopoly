using Monopoly.Models.Cards;
using Monopoly.Models.Cases;
using System.Collections.Generic;

namespace Monopoly.Models
{
    public class Game
    {
        #region Events
        // Event : show a textual message on the interface
        public event MessageHandler Message;
        public delegate void MessageHandler(Game game, string message);

        // Event : change the current player
        public event CurrentPlayerChangedHandler CurrentPlayerChanged;
        public delegate void CurrentPlayerChangedHandler(Game game);
        #endregion

        #region Properties
        /// <summary>
        /// List of participants in the game
        /// </summary>
        public List<Player> Players { get; private set; }

        /// <summary>
        /// Index of the current player (in Game.Players)
        /// </summary>
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

                new StreetProperty(PropertyColor.DarkPurple, "Cour du Soleil", 60, 50, new int[] { 2, 10, 30, 90, 160, 250 }),
                new CardCase(CardType.CommunityChest),
                new StreetProperty(PropertyColor.DarkPurple, "Route de Mercure", 60, 50, new int[] { 4, 20, 60, 180, 320, 450 }),
                new TaxCase(TaxCase.Tax.IncomeTax),
                new StationProperty("Station Caducée"),
                new StreetProperty(PropertyColor.LightBlue, "Avenue de Vénus", 100, 50, new int[] { 6, 30, 90, 270, 400, 550 }),
                new CardCase(CardType.Chance),
                new StreetProperty(PropertyColor.LightBlue, "Place terrienne", 100, 50, new int[] { 6, 30, 90, 270, 400, 550 }),
                new StreetProperty(PropertyColor.LightBlue, "Passage lunaire", 120, 50, new int[] { 8, 40, 100, 300, 450, 600 }),

                new JailCase(),
                new StreetProperty(PropertyColor.Pink, "Désert martien", 140, 100, new int[] { 10, 50, 150, 450, 625, 750 }),
                new UtilityProperty("Voltali Energies"),
                new StreetProperty(PropertyColor.Pink, "Sentier des météores", 140, 100, new int[] { 10, 50, 150, 450, 625, 750 }),
                new StreetProperty(PropertyColor.Pink, "Boulevard de Jupiter", 160, 100, new int[] { 12, 60, 180, 500, 700, 900 }),
                new StationProperty("Station Titania"),
                new StreetProperty(PropertyColor.Orange, "Aire d’Europa", 180, 100, new int[] { 14, 70, 200, 550, 750, 950 }),
                new CardCase(CardType.CommunityChest),
                new StreetProperty(PropertyColor.Orange, "Circuit d'anneaux saturnien", 180, 100, new int[] { 14, 70, 200, 550, 750, 950 }),
                new StreetProperty(PropertyColor.Orange, "Poste de Saturne", 200, 100, new int[] { 16, 80, 220, 600, 800, 1000 }),

                new FreeParkingCase(),
                new StreetProperty(PropertyColor.Red, "Chemin d’Uranus", 220, 150, new int[] { 18, 90, 250, 700, 875, 1050 }),
                new CardCase(CardType.Chance),
                new StreetProperty(PropertyColor.Red, "Ravin de Callisto", 220, 150, new int[] { 18, 90, 250, 700, 875, 1050 }),
                new StreetProperty(PropertyColor.Red, "Côte d’Io", 240, 150, new int[] { 20, 100, 300, 750, 925, 1100 }),
                new StationProperty("Station des Pléiades"),
                new StreetProperty(PropertyColor.Yellow, "Station hivernale neptunienne", 260, 150, new int[] { 22, 110, 330, 800, 975, 1150 }),
                new StreetProperty(PropertyColor.Yellow, "Quartier plutonien", 260, 150, new int[] { 22, 110, 330, 800, 975, 1150 }),
                new UtilityProperty("Vaisseau Aquali"),
                new StreetProperty(PropertyColor.Yellow, "Voie comètiale d'Halley", 280, 150, new int[] { 24, 120, 360, 850, 1025, 1200 }),


                new GoToJailCase(),
                new StreetProperty(PropertyColor.Green, "Point de vue de Hubble", 300, 200, new int[] { 26, 130, 390, 900, 1100, 1275 }),
                new StreetProperty(PropertyColor.Green, "Allée des supernovas", 300, 200, new int[] { 26, 130, 390, 900, 1100, 1275 }),
                new CardCase(CardType.CommunityChest),
                new StreetProperty(PropertyColor.Green, "Promenade des exoplanètes", 320, 200, new int[] { 28, 150, 450, 1000, 1200, 1400 }),
                new StationProperty("Station de la Grande Ourse"),
                new CardCase(CardType.Chance),
                new StreetProperty(PropertyColor.DarkBlue, "Rue des amas globulaires", 350, 200, new int[] { 35, 175, 500, 1100, 1300, 1500 }),
                new TaxCase(TaxCase.Tax.LuxuryTax),
                new StreetProperty(PropertyColor.DarkBlue, "Croisement trou noir", 400, 200, new int[] { 50, 200, 600, 1400, 1700, 2000 }),
            };
        }

        /// <summary>
        /// Start the game
        /// </summary>
        public void Start()
        {
            CurrentPlayerChanged(this);
        }

        /// <summary>
        /// Show a textual message on the screen
        /// </summary>
        /// <param name="message">The message to display</param>
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

            HasPlayed = true;
        }
    }
}
