using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Monopoly.Views
{
    /// <summary>
    /// Game "messages" (informations) wrapper
    /// Shows messages on the top of the screen
    /// </summary>
    class Messages
    {
        /// <summary>
        /// The time where a message is visible on the screen
        /// </summary>
        private const int MESSAGE_TIME_MS = 3000;

        /// <summary>
        /// The time where a message is fading out of the screen
        /// </summary>
        private const int MESSAGE_FADE_OUT_MS = 500;

        Stopwatch stopwatch = Stopwatch.StartNew();
        List<Message> messages = new List<Message>();

        private struct Message
        {
            public readonly string message;
            public readonly long appearedTimestamp;

            public Message(string message, long appearedTimestamp)
            {
                this.message = message;
                this.appearedTimestamp = appearedTimestamp;
            }
        }

        /// <summary>
        /// Add a message to the screen
        /// </summary>
        /// <param name="message">The message to show</param>
        public void Add(string message)
        {
            messages.Add(new Message(message, stopwatch.ElapsedMilliseconds));
        }

        /// <summary>
        /// Draw the messages on the screen
        /// </summary>
        /// <param name="g">Graphics object to draw on</param>
        public void Draw(Graphics g)
        {
            const int MESSAGE_Y = 10;
            const int MESSAGE_X = 5;

            long currentTimestamp = stopwatch.ElapsedMilliseconds;

            foreach (Message m in messages.Where(m => currentTimestamp < m.appearedTimestamp + MESSAGE_TIME_MS + MESSAGE_FADE_OUT_MS))
            {
                int opacity = 255;
                float translateY = 0F;

                // Fade out
                long messageDuration = currentTimestamp - m.appearedTimestamp;
                if (messageDuration >= MESSAGE_TIME_MS)
                {
                    int timeSinceFadeOutStart = (int)(messageDuration - MESSAGE_TIME_MS);
                    double fadeOutProgress = 1.0 * timeSinceFadeOutStart / MESSAGE_FADE_OUT_MS;
                    opacity = (int)(255 * (1.0 - fadeOutProgress));
                    translateY = (float)(-10 * fadeOutProgress);
                }

                g.DrawString(m.message, new Font("Arial", 16), new SolidBrush(Color.FromArgb(opacity, Color.Black)), MESSAGE_X, MESSAGE_Y + translateY);
            }
        }
    }
}
