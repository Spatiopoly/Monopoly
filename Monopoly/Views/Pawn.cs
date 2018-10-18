using Monopoly.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static Monopoly.Models.Player;
using System;
namespace Monopoly.Views
{
    /// <summary>
    /// Displays a pawn on the board
    /// </summary>
    class Pawn
    {
        const int PAWN_SIZE = 32;
        const double SPEED = 200; // Board pixels / second

        private Player _player;
        private Game _game;

        private int _currentCaseIndex = 0;
        private int _order; // Rank of the pawn on its current case

        /// <summary>
        /// Images for each pawn color
        /// </summary>
        private readonly Dictionary<PlayerColor, Image> images = new Dictionary<PlayerColor, Image>() {
            { PlayerColor.Red, Properties.Resources.PawnRed },
            { PlayerColor.Yellow, Properties.Resources.PawnYellow },
            { PlayerColor.Blue, Properties.Resources.PawnBlue },
            { PlayerColor.Purple, Properties.Resources.PawnPurple },
            { PlayerColor.Green, Properties.Resources.PawnGreen }
        };

        /// <summary>
        /// All the pawns instances for each game
        /// </summary>
        private static Dictionary<Game, List<Pawn>> pawns = new Dictionary<Game, List<Pawn>>();

        /// <summary>
        /// Current position (= distanc from the Start case) on the players path.
        /// The CircularNumberProperty class manages the transition between
        /// two positions. To get the still position of the pawn, see PlayersPathPosition
        /// </summary>
        public CircularNumberProperty Position { get; private set; }

        /// <summary>
        /// Get the still position of the pawn on the players path
        /// (= the place where the pawn should be at the end of the transition)
        /// </summary>
        public int StillPosition
        {
            get
            {
                List<Pawn> thisCasePawns = GetPawnsOnCase(_currentCaseIndex)
                    .OrderBy(p => p._order)
                    .ToList();

                int pawnNumber = thisCasePawns
                    .IndexOf(this);

                int casePosition = GameView.GetCaseOnPlayersPath(_currentCaseIndex);

                // Small cases only : overlap the pawns if there are too many
                int queueOffset = PAWN_SIZE * pawnNumber;

                int pawnsCount = thisCasePawns.Count;
                if (pawnsCount >= 3 && _currentCaseIndex % 10 != 0)
                {
                    if (pawnsCount == 3 || pawnsCount == 4)
                        queueOffset /= 2;
                    else
                        queueOffset /= 3;
                }

                return casePosition - queueOffset;
            }
        }

        /// <summary>
        /// Create a new pawn for a player
        /// </summary>
        /// <param name="player">The player associated with the pawn</param>
        /// <param name="game"></param>
        /// <param name="playerIndex">The index of the player in the list</param>
        public Pawn(Player player, Game game)
        {
            _player = player;
            _game = game;

            int playerIndex = game.Players.IndexOf(player);
            _order = playerIndex;

            // Compute the total path length
            PointF[] path = GameView.playersPathPoints;
            float totalPathLength = 0;
            for (int i = 0; i < path.Length; i++)
            {
                PointF thisPoint = path[i];
                PointF nextPoint = path[i != path.Length - 1 ? i + 1 : 0];

                totalPathLength += (float)Math.Sqrt(Math.Pow(nextPoint.X - thisPoint.X, 2) + Math.Pow(nextPoint.Y - thisPoint.Y, 2));
            }

            // Compute the initial position
            int firstCaseEnd = GameView.GetCaseOnPlayersPath(0);
            int initialPosition = firstCaseEnd - (PAWN_SIZE + 5) * playerIndex;
            Position = new CircularNumberProperty(initialPosition, totalPathLength, 3, TransitionTimingFunction.EaseInOut);

            player.CurrentCaseChanged += Player_CurrentCaseChanged;

            // Add the pawn to `pawns`
            if (!pawns.ContainsKey(game))
                pawns.Add(game, new List<Pawn>());

            pawns[game].Add(this);
        }

        /// <summary>
        /// Plays the move animation when a player moves
        /// </summary>
        /// <param name="_">The player who moves</param>
        /// <param name="oldCaseIndex">Index of the old case of the player</param>
        /// <param name="newCaseIndex">Index of the new case of the player</param>
        private void Player_CurrentCaseChanged(Player _, int oldCaseIndex, int newCaseIndex)
        {
            Position.Set(GameView.GetCaseOnPlayersPath(newCaseIndex));
            Position.TransitionDuration = Math.Abs(newCaseIndex - oldCaseIndex) * 0.5;

            // Compute the new rank of the pawn (rank = order of the pawns on a case)
            int pawnsOnNewCase = GetPawnsOnCase(newCaseIndex).Count;
            _order = pawnsOnNewCase; 

            _currentCaseIndex = newCaseIndex;

            // Update the position of all the pawns on the old case
            // + all the pawns on the new case (to overlap if there are too many pawns)
            IEnumerable<Pawn> pawnsToUpdate = 
                GetPawnsOnCase(oldCaseIndex)
                .Concat(GetPawnsOnCase(newCaseIndex));

            foreach (Pawn p in pawnsToUpdate)
            {
                float currentPosition = p.Position.DisplayedValue;
                int newPosition = p.StillPosition;

                float distanceToTravel = newPosition - currentPosition;
                if (distanceToTravel < 0)
                    distanceToTravel += p.Position.MaximumValue;

                p.Position.TransitionDuration = distanceToTravel * (1 / SPEED);
                p.Position.Set(newPosition, CircularNumberProperty.TransitionDirection.Up);
            }
        }

        /// <summary>
        /// Draw the pawn on the board
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            float position = Position.DisplayedValue - PAWN_SIZE / 2;
            PointF point = GameView.GetPointOnPlayersPath(position);
            var rectangle = new RectangleF(point.X - PAWN_SIZE / 2, point.Y - PAWN_SIZE / 2, PAWN_SIZE, PAWN_SIZE);

            if (images.ContainsKey(_player.Color))
            {
                g.DrawImage(images[_player.Color], rectangle);
            }
            else
            {
                g.FillEllipse(new SolidBrush(_player.Color.GetColor()), rectangle);
            }
        }

        /// <summary>
        /// Get all the pawns on a case
        /// </summary>
        /// <param name="caseIndex">The case index</param>
        /// <returns>All the pawns who are on this case</returns>
        private List<Pawn> GetPawnsOnCase(int caseIndex)
        {
            return pawns[_game]
                .Where(p => p._currentCaseIndex == caseIndex)
                .ToList();
        }
    }
}
