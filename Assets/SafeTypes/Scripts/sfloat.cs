using System;

namespace SafeTypes
{
    // Based on a practical tutorial to hack (and protect) Unity games 
    // Alan Zucconi. (2015).
    // http://www.alanzucconi.com/2015/09/02/a-practical-tutorial-to-hack-and-protect-unity-games/

    // Notes.
    // Despite being faster than Symmetric encryption, the safe type is not as fast as the built-in type 
    // since it needs to calculate the true value for every operation.

    /// <summary>
    /// Safe Single type used to prevent memory alteration.
    /// </summary>
    [Serializable]
    public struct sfloat : IEquatable<float>, IEquatable<sfloat>, IFormattable
    {
        /// <summary>
        /// The value stored in the memory.
        /// </summary>
        float value;

        /// <summary>
        /// A random generated offset used to disguise the value stored.
        /// </summary>
        float offset;

        static Random rng = new Random();

        sfloat(float value)
        {
            offset = rng.Next(1000);

            // The value is camouflaged in memory by adding a random value.
            this.value = value + offset;
        }

        /// <summary>
        /// Returns the true value of this instance. 
        /// </summary>
        float GetValue()
        {
            return value - offset;
        }

        #region OPERATORS

        public static implicit operator float(sfloat v)
        {
            return v.GetValue();
        }

        public static implicit operator sfloat(float v)
        {
            return new sfloat(v);
        }

        #endregion

        #region INTERFACES METHODS AND OVERRIDES

        public bool Equals(float other)
        {
            return GetValue().Equals(other);
        }

        public bool Equals(sfloat other)
        {
            return GetValue().Equals(other.GetValue());
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == GetType() && Equals((sfloat)obj);
        }

        public override int GetHashCode()
        {
            return GetValue().GetHashCode();
        }

        public override string ToString()
        {
            return GetValue().ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return GetValue().ToString(format, formatProvider);
        }

        #endregion

        /// <summary>
        /// Use this method to debug the values of this type.
        /// </summary>
        public string Debug()
        {
            return String.Format("(Stored Value: {0}, Offset: {1}, Value: {2})", value, offset, GetValue());
        }
    }
}