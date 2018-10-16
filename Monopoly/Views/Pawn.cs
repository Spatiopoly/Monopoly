using Monopoly.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using static Monopoly.Models.Player;

namespace Monopoly.Views
{
    /// <summary>
    /// Display a pawn on the board
    /// </summary>
    class Pawn
    {
        const int PAWN_SIZE = 32;
        const double CASES_PER_SECOND = 0.5; // Speed of the pawn 

        private Player player;
        private Dictionary<PlayerColor, Image> images = new Dictionary<PlayerColor, Image>() {
            { PlayerColor.Red, Properties.Resources.PawnRed },
            { PlayerColor.Yellow, Properties.Resources.PawnYellow },
            { PlayerColor.Blue, Properties.Resources.PawnBlue },
            { PlayerColor.Purple, Properties.Resources.PawnPurple },
            { PlayerColor.Green, Properties.Resources.PawnGreen }
        };

        public CircularNumberProperty Position { get; private set; }

        /// <summary>
        /// Create a new pawn with a player
        /// </summary>
        /// <param name="player">The player associated with the pawn</param>
        /// <param name="playerIndex">The index of the player in the list</param>
        public Pawn(Player player, int playerIndex)
        {
            this.player = player;

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
        }

        private void Player_CurrentCaseChanged(Player player, int oldCaseIndex, int newCaseIndex)
        {
            Position.TransitionDuration = Math.Abs(newCaseIndex - oldCaseIndex) * CASES_PER_SECOND;

            int nextPointDistance = GameView.GetCaseOnPlayersPath(newCaseIndex);
            Position.Set(nextPointDistance, CircularNumberProperty.TransitionDirection.Up);
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

            if (images.ContainsKey(player.Color))
            {
                g.DrawImage(images[player.Color], rectangle);
            }
            else
            {
                g.FillEllipse(new SolidBrush(player.Color.GetColor()), rectangle);
            }
        }
    }
}
