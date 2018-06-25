using System;

namespace CryptoTypes
{
    // Based on a practical tutorial to hack (and protect) Unity games 
    // Alan Zucconi. (2015).
    // http://www.alanzucconi.com/2015/09/02/a-practical-tutorial-to-hack-and-protect-unity-games/

    // Notes.
    // Despite being faster than Symmetric encryption, the safe type is not as fast as the built-in type 
    // since it needs to calculate the true value for every operation.

    /// <summary>
    /// 32-bit signed integer type used to prevent memory hacking.
    /// </summary>
    [Serializable]
    public struct CryptoInt : IEquatable<int>, IEquatable<CryptoInt>, IFormattable
    {
        /// <summary>
        /// The value stored in the memory.
        /// </summary>
        [UnityEngine.SerializeField] int value;

        /// <summary>
        /// A random generated offset used to disguise the value stored.
        /// </summary>
        [UnityEngine.SerializeField] int offset;

        static Random rng = new Random();

        CryptoInt(int value)
        {
            offset = rng.Next(17);

            // The value is camouflaged in memory by adding a random value.
            this.value = value + offset;
        }

        /// <summary>
        /// Returns the decrypted value of this instance.
        /// </summary>
        int GetValue()
        {
            return value - offset;
        }

        /// <summary>
        /// Returns the random generated offset.
        /// </summary>
        public int GetOffset()
        {
            return offset;
        }

        #region OPERATORS

        public static implicit operator int(CryptoInt v)
        {
            return v.GetValue();
        }

        public static implicit operator CryptoInt(int v)
        {
            return new CryptoInt(v);
        }

        public static CryptoInt operator ++(CryptoInt i)
        {
            return new CryptoInt(i.GetValue() + 1);
        }

        public static CryptoInt operator --(CryptoInt i)
        {
            return new CryptoInt(i.GetValue() - 1);
        }

        #endregion

        #region INTERFACES METHODS AND OVERRIDES

        public bool Equals(int other)
        {
            return GetValue().Equals(other);
        }

        public bool Equals(CryptoInt other)
        {
            return GetValue().Equals(other.GetValue());
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == GetType() && Equals((CryptoInt)obj);
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
            return String.Format(GetType().ToString() + " (Stored Value: {0}, Offset: {1}, Value: {2})", value, offset, GetValue());
        }
    }
}