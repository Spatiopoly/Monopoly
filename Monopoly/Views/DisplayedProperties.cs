using System;
using System.Diagnostics;
using System.Drawing;

namespace Monopoly.Views
{
    /// <summary>
    /// Transition easing, such as in CSS
    /// </summary>
    public enum TransitionTimingFunction
    {
        Linear,
        EaseInOut,
    }

    /// <summary>
    /// This class allows us to create a displayed property such as in CSS.
    /// The transitions between two states can be controlled (duration and type).
    /// 
    /// Use DisplayedProperty<T>.DisplayedValue to get the value that should be shown on screen.
    /// Use DisplayedProperty<T>.Set() to create a new state.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class DisplayedProperty<T>
    {
        protected Stopwatch stopwatch = Stopwatch.StartNew();
        private int transitionDurationMs = 0;

        private T currentValue;
        private T nextValue;

        public DisplayedProperty(T defaultValue)
        {
            currentValue = defaultValue;
            nextValue = defaultValue;
        }

        public DisplayedProperty(T defaultValue, double transitionDuration) : this(defaultValue)
        {
            TransitionDuration = transitionDuration;
        }

        public DisplayedProperty(T defaultValue, double transitionDuration, TransitionTimingFunction easing) : this(defaultValue, transitionDuration)
        {
            TransitionEasing = easing;
        }

        #region Properties
        /// <summary>
        /// Get the current displayed value (current state of the transition)
        /// </summary>
        public T DisplayedValue
        {
            get
            {
                long currentTimestamp = stopwatch.ElapsedMilliseconds;

                if (currentTimestamp > transitionDurationMs)
                {
                    return nextValue;
                }

                double progress = Ease(TransitionEasing, (double)currentTimestamp / transitionDurationMs);
                return GetIntermediateValue(currentValue, nextValue, progress);
            }
        }

        /// <summary>
        /// Transition duration (in seconds)
        /// </summary>
        public double TransitionDuration
        {
            get => transitionDurationMs / 1000.0;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The duration should be positive");
                }

                transitionDurationMs = (int)Math.Round(value * 1000);
            }
        }

        /// <summary>
        /// Transition easing
        /// </summary>
        public TransitionTimingFunction TransitionEasing { get; set; } = TransitionTimingFunction.Linear;
        #endregion

        #region Methods
        /// <summary>
        /// Set a new value which will be displayed on screen after the transition is completed
        /// </summary>
        /// <param name="newValue">The new value</param>
        public virtual void Set(T newValue)
        {
            currentValue = DisplayedValue;
            nextValue = newValue;
            stopwatch.Restart();
        }

        /// <summary>
        /// Get the intermediate value between two values
        /// </summary>
        /// <param name="previousValue">The previous value</param>
        /// <param name="nextValue">The next value</param>
        /// <param name="progress">Progress between the two values (from 0.0 to 1.0)</param>
        /// <returns></returns>
        protected abstract T GetIntermediateValue(T previousValue, T nextValue, double progress);

        /// <summary>
        /// Apply a transition timing function to a double
        /// </summary>
        /// <param name="easing">The easing (transition timing function) to apply</param>
        /// <param name="progress">The progress (from 0.0 to 1.0)</param>
        /// <returns>The eased progress (from 0.0 to 1.0)</returns>
        private static double Ease(TransitionTimingFunction easing, double progress)
        {
            switch (easing)
            {
                case TransitionTimingFunction.Linear:
                    return progress;
                case TransitionTimingFunction.EaseInOut: // https://stackoverflow.com/a/25730573
                    return Math.Pow(progress, 2) * (3.0 - 2.0 * progress);
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion
    }

    /// <summary>
    /// Number property
    /// (Uses float because the Windows Forms uses float everywhere)
    /// </summary>
    class NumberProperty : DisplayedProperty<float>
    {
        public NumberProperty(float defaultValue)
            : base(defaultValue) { }

        public NumberProperty(float defaultValue, double transitionDuration)
            : base(defaultValue, transitionDuration) { }

        public NumberProperty(float defaultValue, double transitionDuration, TransitionTimingFunction easing)
            : base(defaultValue, transitionDuration, easing) { }

        protected override float GetIntermediateValue(float previousValue, float nextValue, double progress)
        {
            float difference = nextValue - previousValue;
            return previousValue + (float)(progress * difference);
        }
    }

    /// <summary>
    /// Position on a circle or on a path
    /// 
    /// Example:
    /// var position = new CircularNumberProperty(350, 360);
    /// position.Add(20);
    /// 
    /// DisplayedValue will be equal to 350, then 355, 0, 5, and 10.
    /// </summary>
    class CircularNumberProperty : DisplayedProperty<float>
    {
        public enum TransitionDirection { Up, Down }

        private TransitionDirection _currentTransitionDirection;

        public float MaximumValue { get; private set; }

        public CircularNumberProperty(float defaultValue, float maximumValue)
            : base(defaultValue)
        {
            MaximumValue = maximumValue;
        }

        public CircularNumberProperty(float defaultValue, float maximumValue, double transitionDuration)
            : base(defaultValue, transitionDuration)
        {
            MaximumValue = maximumValue;
        }

        public CircularNumberProperty(float defaultValue, float maximumValue, double transitionDuration, TransitionTimingFunction easing)
            : base(defaultValue, transitionDuration, easing)
        {
            MaximumValue = maximumValue;
        }

        /// <summary>
        /// Set a new value with an automatic direction
        /// (The transition won't pass through MaximumValue even if it's the closest path)
        /// </summary>
        /// <param name="newValue"></param>
        public override void Set(float newValue)
        {
            var direction = newValue > DisplayedValue
                ? TransitionDirection.Up
                : TransitionDirection.Down;

            Set(newValue, direction);
        }

        /// <summary>
        /// Set a new value specifying a transition direction
        /// </summary>
        /// <param name="newValue">The new value</param>
        /// <param name="direction">The transition direction (up or down)</param>
        public void Set(float newValue, TransitionDirection direction)
        {
            _currentTransitionDirection = direction;
            base.Set(newValue);
        }

        protected override float GetIntermediateValue(float previousValue, float nextValue, double progress)
        {
            if (_currentTransitionDirection == TransitionDirection.Down)
                throw new NotImplementedException("Not supported yet");

            float difference = nextValue - previousValue;
            if (difference < 0 && _currentTransitionDirection == TransitionDirection.Up)
            {
                difference += MaximumValue;
            }

            float newValue = previousValue + (float)(progress * difference);

            if (newValue > MaximumValue)
                newValue -= MaximumValue;

            return newValue;
        }
    }

    /// <summary>
    /// Color property
    /// </summary>
    class ColorProperty : DisplayedProperty<Color>
    {
        public ColorProperty(Color defaultValue)
            : base(defaultValue) { }

        public ColorProperty(Color defaultValue, double transitionDuration)
            : base(defaultValue, transitionDuration) { }

        public ColorProperty(Color defaultValue, double transitionDuration, TransitionTimingFunction easing)
            : base(defaultValue, transitionDuration, easing) { }

        protected override Color GetIntermediateValue(Color previousValue, Color nextValue, double progress)
        {
            return Color.FromArgb(
                previousValue.A + (int)(progress * (nextValue.A - previousValue.A)),
                previousValue.R + (int)(progress * (nextValue.R - previousValue.R)),
                previousValue.G + (int)(progress * (nextValue.G - previousValue.G)),
                previousValue.B + (int)(progress * (nextValue.B - previousValue.B))
            );
        }
    }

}
