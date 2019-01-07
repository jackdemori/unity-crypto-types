using System;

namespace CryptoTypes
{
    /// <summary>
    /// Random Number Generator based on xorshift.
    /// </summary>
    public partial struct RNG
    {
        uint state;

        /// <summary>
        /// Constructs a Random instance with a given seed value. The seed must be non-zero.
        /// </summary>
        public RNG (uint seed)
        {
            state = seed;
            CheckInitState();
            NextState();
        }

        /// <summary>
        /// Returns a uniformly random sbyte value.
        /// </summary>
        public sbyte NextSByte ()
        {
            return (sbyte)(NextState() ^ -129);
        }

        /// <summary>
        /// Returns a uniformly random int value in the interval [0, max).
        /// </summary>
        public sbyte NextSByte (short max)
        {
            CheckNextIntMax(max);
            return (sbyte)((NextState() * (ushort)max) >> 8);
        }

        /// <summary>
        /// Fills the elements of a specified array of sbytes with random numbers.
        /// </summary>
        public void NextSByte (sbyte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = NextSByte();
        }

        /// <summary>
        /// Returns a non-negative random byte.
        /// </summary>
        public byte NextByte ()
        {
            return (byte)((NextState() * 255) >> 8);
        }

        /// <summary>
        /// Returns a uniformly random int value in the interval [-2147483647, 2147483647].
        /// </summary>
        public int NextInt ()
        {
            return (int)NextState() ^ -2147483648;
        }

        /// <summary>
        /// Returns a uniformly random int value in the interval [0, max).
        /// </summary>
        public int NextInt (int max)
        {
            CheckNextIntMax(max);
            return (int)((NextState() * (ulong)max) >> 32);
        }

        /// <summary>
        /// Returns a uniformly random uint value in the interval [0, 4294967294].
        /// </summary>
        public uint NextUInt ()
        {
            return NextState() - 1u;
        }

        private void CheckInitState ()
        {
            if (state == 0)
                throw new ArgumentException("Seed must be non-zero");
        }

        private void CheckState ()
        {
            if (state == 0)
                throw new ArgumentException("Invalid state 0. Random object has not been properly initialized");
        }

        private void CheckNextIntMax (int max)
        {
            if (max < 0)
                throw new ArgumentException("Max must be positive");
        }

        private uint NextState ()
        {
            CheckState();
            uint t = state;
            state ^= state << 13;
            state ^= state >> 17;
            state ^= state << 5;
            return t;
        }
    }
}