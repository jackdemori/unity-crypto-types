using System;

namespace CryptoTypes
{
    // Based on a practical tutorial to hack (and protect) Unity games 
    // Alan Zucconi. (2015).
    // http://www.alanzucconi.com/2015/09/02/a-practical-tutorial-to-hack-and-protect-unity-games/

    // Notes.
    // Despite being faster than Symmetric encryption, the crypto type is not as fast as the built-in type 
    // since it needs to calculate the true value for each operation.

    /// <summary>
    /// Single-precision floating point number type used to prevent memory hacking.
    /// </summary>
    [Serializable]
    public partial struct CryptoFloat : IEquatable<float>, IEquatable<CryptoFloat>, IFormattable
    {
        /// <summary>
        /// Represents a pseudo-random number generator, which is a device that produces a sequence of numbers that meet certain statistical requirements for randomness.
        /// </summary>
        static RNG random = new RNG(0x3E128EE1u);

        /// <summary>
        /// The value stored in the memory.
        /// </summary>
        [UnityEngine.SerializeField] float value;

        /// <summary>
        /// A random generated offset used to disguise the true value of this type.
        /// </summary>
        [UnityEngine.SerializeField] sbyte offset;

        CryptoFloat (float value)
        {
            offset = random.NextSByte();

            // The value is camouflaged in memory by adding a random value.
            this.value = value + offset;
        }

        /// <summary>
        /// Returns the decrypted value of this instance. 
        /// </summary>
        float GetValue()
        {
            return value - offset;
        }

        /// <summary>
        /// Returns the random generated offset.
        /// </summary>
        public sbyte GetOffset ()
        {
            return offset;
        }

        #region OPERATORS

        public static implicit operator float(CryptoFloat v)
        {
            return v.GetValue();
        }

        public static implicit operator CryptoFloat(float v)
        {
            return new CryptoFloat(v);
        }

        #endregion

        #region INTERFACES METHODS AND OVERRIDES

        public bool Equals(float other)
        {
            return GetValue().Equals(other);
        }

        public bool Equals(CryptoFloat other)
        {
            return GetValue().Equals(other.GetValue());
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == GetType() && Equals((CryptoFloat)obj);
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
        /// Use this method to debug the value of this type.
        /// </summary>
        public string Debug()
        {
            return string.Format(GetType().ToString() + " (Stored Value: {0}, Offset: {1}, Value: {2})", value, offset, GetValue());
        }
    }
}