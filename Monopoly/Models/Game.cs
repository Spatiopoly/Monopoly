using Monopoly.Models.Cards;
using Monopoly.Models.Cases;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

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
        public int LastFirstDiceResult { get; set; }

        public int LastSecDiceReslut { get; set; }

        public int ResultFirstDice { get; set; } = 0;
        public int ResultSecDice { get; set; } = 0;

        public AbstractCard LastSpecialCard { get; set; }
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

            Cards = new List<AbstractCard>() {
                new PayMoneyCard("Visite chez le spatio-dentiste", 200, CardType.CommunityChest, PayMoneyCard.PayMoneyCardType.Normale),
                new AdvanceToStartCaseCard(CardType.Chance),
                new AdvanceToSpecificCaseCard(24, CardType.Chance),
                new AdvanceToSpecificCaseCard(11, CardType.Chance),
                new AdvanceToNextSpecialCaseCard(AdvanceToNextSpecialCaseCard.SpecialCaseType.Utility, CardType.Chance),
                new AdvanceToNextSpecialCaseCard(AdvanceToNextSpecialCaseCard.SpecialCaseType.Station, CardType.Chance),
                new ReceiveMoneyCard("L'Empire dédommage votre vaisseau qu'un stormtrooper a abimé.", 50, ReceiveMoneyCard.ReceiveMoneyCardType.Normale ,CardType.Chance), 
                //Faire classe carte sortie prison => elle a un owner, fait aller de prison à parloir
                //Faire la carte qui recule de 3 cases
                new GoToPrisonCard(CardType.Chance),
                new PayMoneyCard("Travaux de réparations", 0, CardType.Chance, PayMoneyCard.PayMoneyCardType.Reparations),
                new PayMoneyCard("Vous achetez Spatiopoly AR 36D du futur", 15, CardType.Chance, PayMoneyCard.PayMoneyCardType.Normale),
                new AdvanceToSpecificCaseCard(5, CardType.Chance),
                new AdvanceToSpecificCaseCard(39, CardType.Chance),
                new PayMoneyCard("Vous avez été élu président de l'univers", 0, CardType.Chance, PayMoneyCard.PayMoneyCardType.Presidence),
                new ReceiveMoneyCard("Vos chasseurs de prime ont découvert un spatio-trésor ultime", 150,ReceiveMoneyCard.ReceiveMoneyCardType.Normale ,CardType.Chance),
                new ReceiveMoneyCard("Vous gagnez une compétition de pêche aux vers spatiaux", 100, ReceiveMoneyCard.ReceiveMoneyCardType.Normale, CardType.Chance),

                new AdvanceToStartCaseCard(CardType.CommunityChest),
                new ReceiveMoneyCard("La banque galactique rémunère les VIP", 200, ReceiveMoneyCard.ReceiveMoneyCardType.Normale, CardType.CommunityChest),
                new PayMoneyCard("Service technique de votre vaisseau", 50, CardType.CommunityChest, PayMoneyCard.PayMoneyCardType.Normale),
                // Faire carte sortie prison => comme en haut sauf en community chest
                new GoToPrisonCard(CardType.CommunityChest),
                new ReceiveMoneyCard("Organisation d'un tournoi de Spatiogolf", 50, ReceiveMoneyCard.ReceiveMoneyCardType.Recolte, CardType.CommunityChest),
                new ReceiveMoneyCard("Vos mercenaires ont retrouvé un débiteur", 100, ReceiveMoneyCard.ReceiveMoneyCardType.Normale, CardType.CommunityChest),
                new ReceiveMoneyCard("Remboursement de pièces nanotechs défecteuses", 20, ReceiveMoneyCard.ReceiveMoneyCardType.Normale, CardType.CommunityChest),
                new ReceiveMoneyCard("C'est ton anniversaire!", 10, ReceiveMoneyCard.ReceiveMoneyCardType.Normale, CardType.CommunityChest),
                new ReceiveMoneyCard("Remboursement de l'assurance de votre vaisseau", 100, ReceiveMoneyCard.ReceiveMoneyCardType.Normale, CardType.CommunityChest),
                new PayMoneyCard("Frais de téléportation intragalactique", 100, CardType.CommunityChest, PayMoneyCard.PayMoneyCardType.Normale),
                new PayMoneyCard("Frais de l'école de pilotage", 150, CardType.CommunityChest, PayMoneyCard.PayMoneyCardType.Normale),
                new ReceiveMoneyCard("Vous aidez un ami à réparer son vaisseau", 25, ReceiveMoneyCard.ReceiveMoneyCardType.Normale, CardType.CommunityChest),
                new PayMoneyCard("Impots sur les réparations des rues", 0, CardType.CommunityChest, PayMoneyCard.PayMoneyCardType.Impots),
                new ReceiveMoneyCard("Vous gagnez le 3ème prix du Grand Concours Centaurien", 10, ReceiveMoneyCard.ReceiveMoneyCardType.Normale, CardType.CommunityChest),
                new ReceiveMoneyCard("Vous vendez le vaisseau cassé de votre grand-mère", 100, ReceiveMoneyCard.ReceiveMoneyCardType.Normale, CardType.CommunityChest)
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
        public void PlayDice(int resultFirstDice, int resultSecDice)
        {
            int diceSum = resultFirstDice + resultSecDice;
            LastFirstDiceResult = resultFirstDice;
            LastSecDiceReslut = resultSecDice;
            const int JAIL_CASE_INDEX = 10;
            //Move player if he's not a prisoner or if he is his throw must be a double
            if ((CurrentPlayer.IsInJail && resultFirstDice == resultSecDice) || !CurrentPlayer.IsInJail)
            {
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

                if (CurrentPlayer.IsInJail && resultFirstDice != resultSecDice)
                {
                    CurrentPlayer.GoToCase(JAIL_CASE_INDEX);
                    Cases[CurrentPlayer.CurrentCaseIndex].Land(this);
                }

                //Throw if palyers ins't in prison and current thorw was a double
                if (!CurrentPlayer.IsInJail && resultFirstDice == resultSecDice)
                {
                    CurrentPlayer.NbDoubles++;
                    CurrentPlayer.IsInJail = CurrentPlayer.NbDoubles == 3;


                    if (CurrentPlayer.IsInJail)
                    {
                        CurrentPlayer.GoToCase(JAIL_CASE_INDEX);
                        Cases[CurrentPlayer.CurrentCaseIndex].Land(this);
                        HasPlayed = true;
                        CurrentPlayer.NbDoubles = 0;

                    }
                    else
                    {
                        SendMessage("Le joueur " + CurrentPlayer.Name + " peut rejouer :3");
                        if (MessageBox.Show("Voulez-vous rejouer ?", "rejouer ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            HasPlayed = true; // the player can play again
                            SendMessage("Le joueur " + CurrentPlayer.Name + " a choisi de rejouer");
                        }
                        else
                        {
                            SendMessage("Le joueur " + CurrentPlayer.Name + " a choisi de ne pas rejouer");
                            HasPlayed = true;
                            CurrentPlayer.NbDoubles = 0;
                        }

                    }
                }
                else
                {
                    CurrentPlayer.NbDoubles = 0;
                    HasPlayed = true;
                    if (CurrentPlayer.IsInJail)
                    {
                        CurrentPlayer.IsInJail = false;
                    }
                }

                CurrentPlayer.LastFirstDiceResult = resultFirstDice;
                CurrentPlayer.LastSecDiceReslut = resultSecDice;

            }
        }

        /// <summary>
        /// Know if a player has a monopoly (= has all the streets of a specified color)
        /// </summary>
        /// <param name="player">Player</param>
        /// <param name="monopoly">The street group</param>
        public bool HasMonopoly(Player player, PropertyColor monopoly)
        {
            return Cases
                .Where(c => c is StreetProperty)
                .Where(c => (c as StreetProperty).Group == monopoly)
                .All(c => (c as StreetProperty).Owner == player);
        }
    }
}
