using System;

namespace DddInPractice.Logic
{
    public sealed class Money : ValueObject<Money>
    {
        public static readonly Money None = new Money(0, 0, 0, 0,
            0, 0, 0, 0);

        public static readonly Money OnePenny = new Money(1, 0, 0, 0,
            0, 0, 0, 0);

        public static readonly Money TwoPence = new Money(0, 1, 0, 0,
            0, 0, 0, 0);

        public static readonly Money FivePence = new Money(0, 0, 1, 0,
            0, 0, 0, 0);

        public static readonly Money TenPence = new Money(0, 0, 0, 1,
            0, 0, 0, 0);

        public static readonly Money TwentyPence = new Money(0, 0, 0, 0,
            1, 0, 0, 0);

        public static readonly Money FiftyPence = new Money(0, 0, 0, 0,
            0, 1, 0, 0);

        public static readonly Money OnePound = new Money(0, 0, 0, 0,
            0, 0, 1, 0);

        public static readonly Money TwoPound = new Money(0, 0, 0, 0,
            0, 0, 0, 1);

        public int OnePennyCount { get; }
        public int TwoPenceCount { get; }
        public int FivePenceCount { get; }
        public int TenPenceCount { get; }
        public int TwentyPenceCount { get; }
        public int FiftyPenceCount { get; }
        public int OnePoundCount { get; }
        public int TwoPoundCount { get; }

        public Money(
            int onePennyCount,
            int twoPenceCount,
            int fivePenceCount,
            int tenPenceCount,
            int twentyPenceCount,
            int fiftyPenceCount,
            int onePoundCount,
            int twoPoundCount)
        {
            if (onePennyCount < 0)
                throw new InvalidOperationException();
            if (twoPenceCount < 0)
                throw new InvalidOperationException();
            if (fivePenceCount < 0)
                throw new InvalidOperationException();
            if (tenPenceCount < 0)
                throw new InvalidOperationException();
            if (twentyPenceCount < 0)
                throw new InvalidOperationException();
            if (fiftyPenceCount < 0)
                throw new InvalidOperationException();
            if (onePoundCount < 0)
                throw new InvalidOperationException();
            if (twoPoundCount < 0)
                throw new InvalidOperationException();

            OnePennyCount = onePennyCount;
            TwoPenceCount = twoPenceCount;
            FivePenceCount = fivePenceCount;
            TenPenceCount = tenPenceCount;
            TwentyPenceCount = twentyPenceCount;
            FiftyPenceCount = fiftyPenceCount;
            OnePoundCount = onePoundCount;
            TwoPoundCount = twoPoundCount;
            OnePoundCount = onePoundCount;
            TwoPoundCount = twoPoundCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OnePennyCount + money2.OnePennyCount,
                money1.TwoPenceCount + money2.TwoPenceCount,
                money1.FivePenceCount + money2.FivePenceCount,
                money1.TenPenceCount + money2.TenPenceCount,
                money1.TwentyPenceCount + money2.TwentyPenceCount,
                money1.FiftyPenceCount + money2.FiftyPenceCount,
                money1.OnePoundCount + money2.OnePoundCount,
                money1.TwoPoundCount + money2.TwoPoundCount
                );
            return sum;
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.OnePennyCount - money2.OnePennyCount,
                money1.TwoPenceCount - money2.TwoPenceCount,
                money1.FivePenceCount - money2.FivePenceCount,
                money1.TenPenceCount - money2.TenPenceCount,
                money1.TwentyPenceCount - money2.TwentyPenceCount,
                money1.FiftyPenceCount - money2.FiftyPenceCount,
                money1.OnePoundCount - money2.OnePoundCount,
                money1.TwoPoundCount - money2.TwoPoundCount
            );
        }
        protected override bool EqualsCore(Money other)
        {
            return OnePennyCount == other.OnePennyCount &&
                   TwoPenceCount == other.TwoPenceCount &&
                   FivePenceCount == other.FivePenceCount &&
                   TenPenceCount == other.TenPenceCount &&
                   TwentyPenceCount == other.TwentyPenceCount &&
                   FiftyPenceCount == other.FiftyPenceCount &&
                   OnePennyCount == other.OnePennyCount &&
                   TwoPoundCount == other.TwoPoundCount;
        }

        protected override int GetHashCodeCore()
        {
            int hashCode = OnePennyCount;
            hashCode = (hashCode * 397) ^ TwoPenceCount;
            hashCode = (hashCode * 397) ^ FivePenceCount;
            hashCode = (hashCode * 397) ^ TenPenceCount;
            hashCode = (hashCode * 397) ^ TwentyPenceCount;
            hashCode = (hashCode * 397) ^ FiftyPenceCount;
            hashCode = (hashCode * 397) ^ OnePoundCount;
            hashCode = (hashCode * 397) ^ TwoPoundCount;
            return hashCode;
        }
    }
}