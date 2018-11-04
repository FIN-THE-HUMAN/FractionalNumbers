using System;

namespace Encryption
{
    public class FractionalNumber
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        private FractionalNumber() { }

        public static FractionalNumber GetInstance()
        {
            FractionalNumber n = new FractionalNumber();
            n.Numerator = 0;
            n.Denominator = 1;

            return n;
        }

        private static int GetGreatestCommonDivisor(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }

            return a + b;
        }

        public static FractionalNumber GetInstance(int numerator, int denumerator)
        {
            if (denumerator == 0) throw new DivideByZeroException();
            if (numerator == 0) denumerator = 1;
            if (denumerator < 0)
            {
                denumerator = denumerator * -1;
                numerator = numerator * -1;
            }

            FractionalNumber n = new FractionalNumber();
            int gcd = GetGreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denumerator));
            n.Numerator = numerator / gcd;
            n.Denominator = denumerator / gcd;

            return n;
        }

        public float ToFloat()
        {
            return Numerator / (float)Denominator;
        }

        public double ToDouble()
        {
            return Numerator / (double)Denominator;
        }

        public static FractionalNumber operator +(FractionalNumber f1, FractionalNumber f2)
        {
            FractionalNumber n = new FractionalNumber();
            int numerator;
            int denumerator;
            if (f1.Denominator == f2.Denominator)
            {

                numerator = f1.Numerator + f2.Numerator;
                denumerator = f1.Denominator;
            }
            else
            {
                numerator = f2.Denominator * f1.Numerator + f2.Numerator * f1.Denominator;
                denumerator = f1.Denominator * f2.Denominator;
            }

            int gcd = GetGreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denumerator));
            if (denumerator < 0)
            {
                denumerator = denumerator * -1;
                numerator = numerator * -1;
            }
            n.Numerator = numerator / gcd;
            n.Denominator = denumerator / gcd;
            
            return n;
        }

        public static FractionalNumber operator -(FractionalNumber f1, FractionalNumber f2)
        {
            FractionalNumber n = new FractionalNumber();
            int numerator;
            int denumerator;
            if (f1.Denominator == f2.Denominator)
            {

                numerator = f1.Numerator - f2.Numerator;
                denumerator = f1.Denominator;
            }
            else
            {
                numerator = f2.Denominator * f1.Numerator - f2.Numerator * f1.Denominator;
                denumerator = f1.Denominator * f2.Denominator;
            }

            int gcd = GetGreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denumerator));
            if (denumerator < 0)
            {
                denumerator = denumerator * -1;
                numerator = numerator * -1;
            }
            n.Numerator = numerator / gcd;
            n.Denominator = denumerator / gcd;

            return n;
        }

        public static FractionalNumber operator *(FractionalNumber f1, FractionalNumber f2)
        {
            FractionalNumber n = new FractionalNumber();
            int numerator = f1.Numerator * f2.Numerator;
            int denumerator = f1.Denominator * f2.Denominator;
            int gcd = GetGreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denumerator));
            if (denumerator < 0)
            {
                denumerator = denumerator * -1;
                numerator = numerator * -1;
            }
            n.Numerator = numerator / gcd;
            n.Denominator = denumerator / gcd;

            return n;
        }

        public static FractionalNumber operator /(FractionalNumber f1, FractionalNumber f2)
        {
            if (f2.Numerator == 0) throw new DivideByZeroException();
            FractionalNumber n = new FractionalNumber();
            int numerator = f1.Numerator * f2.Denominator;
            int denumerator = f1.Denominator * f2.Numerator;
            int gcd = GetGreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denumerator));
            if (denumerator < 0)
            {
                denumerator = denumerator * -1;
                numerator = numerator * -1;
            }
            n.Numerator = numerator / gcd;
            n.Denominator = denumerator / gcd;

            return n;
        }

        public static FractionalNumber operator +(FractionalNumber f1, int f2)
        {
            FractionalNumber n = new FractionalNumber();
            int numerator = f1.Numerator + f2 * f1.Denominator;

            n.Numerator = numerator;
            n.Denominator = f1.Denominator;

            return n;
        }

        public static FractionalNumber operator -(FractionalNumber f1, int f2)
        {
            FractionalNumber n = new FractionalNumber();
            int numerator = f1.Numerator - f2 * f1.Denominator;

            n.Numerator = numerator;
            n.Denominator = f1.Denominator;

            return n;
        }

        public static FractionalNumber operator *(FractionalNumber f1, int f2)
        {
            FractionalNumber n = new FractionalNumber();

            int numerator = f1.Numerator * f2;
            int gcd = GetGreatestCommonDivisor(Math.Abs(numerator), Math.Abs(f1.Denominator));
            n.Numerator = numerator / gcd;
            n.Denominator = f1.Denominator / gcd;

            return n;
        }

        public static FractionalNumber operator /(FractionalNumber f1, int f2)
        {
            if (f2 == 0) throw new DivideByZeroException();
            FractionalNumber n = new FractionalNumber();

            int denomirator = f1.Denominator * f2;
            int gcd = GetGreatestCommonDivisor(Math.Abs(f1.Numerator), Math.Abs(denomirator));
            n.Numerator = f1.Numerator / gcd;
            n.Denominator = denomirator / gcd;

            return n;
        }

        public static FractionalNumber operator +(int f2, FractionalNumber f1)
        {
            FractionalNumber n = new FractionalNumber();
            int numerator = f1.Numerator + f2 * f1.Denominator;

            n.Numerator = numerator;
            n.Denominator = f1.Denominator;

            return n;
        }

        public static FractionalNumber operator -(int f2, FractionalNumber f1)
        {
            FractionalNumber n = new FractionalNumber();
            int numerator = f2 * f1.Denominator - f1.Numerator;

            n.Numerator = numerator;
            n.Denominator = f1.Denominator;

            return n;
        }

        public static FractionalNumber operator *(int f2, FractionalNumber f1)
        {
            FractionalNumber n = new FractionalNumber();

            int numerator = f1.Numerator * f2;
            int gcd = GetGreatestCommonDivisor(Math.Abs(numerator), Math.Abs(f1.Denominator));
            n.Numerator = numerator / gcd;
            n.Denominator = f1.Denominator / gcd;

            return n;
        }

        public static FractionalNumber operator /(int f2, FractionalNumber f1)
        {
            if (f1.Numerator == 0) throw new DivideByZeroException();
            FractionalNumber n = new FractionalNumber();

            int numerator = f1.Denominator * f2;
            int gcd = GetGreatestCommonDivisor(Math.Abs(numerator), Math.Abs(f1.Numerator));
            n.Numerator = numerator / gcd;
            n.Denominator = f1.Numerator / gcd;

            return n;
        }

        public static bool operator >(FractionalNumber f1, FractionalNumber f2)
        {
            return (f1 - f2).Numerator > 0;
        }

        public static bool operator <(FractionalNumber f1, FractionalNumber f2)
        {
            return (f1 - f2).Numerator < 0;
        }

        public static bool operator >=(FractionalNumber f1, FractionalNumber f2)
        {
            return (f1 - f2).Numerator >= 0;
        }

        public static bool operator <=(FractionalNumber f1, FractionalNumber f2)
        {
            return (f1 - f2).Numerator <= 0;
        }

        public static bool operator >(int f1, FractionalNumber f2)
        {
            return (f1 - f2).Numerator > 0;
        }

        public static bool operator <(int f1, FractionalNumber f2)
        {
            return (f1 - f2).Numerator < 0;
        }

        public static bool operator >=(int f1, FractionalNumber f2)
        {
            return (f1 - f2).Numerator >= 0;
        }

        public static bool operator <=(int f1, FractionalNumber f2)
        {
            return (f1 - f2).Numerator <= 0;
        }

        public static bool operator >(FractionalNumber f1, int f2)
        {
            return (f1 - f2).Numerator > 0;
        }

        public static bool operator <(FractionalNumber f1, int f2)
        {
            return (f1 - f2).Numerator < 0;
        }

        public static bool operator >=(FractionalNumber f1, int f2)
        {
            return (f1 - f2).Numerator >= 0;
        }

        public static bool operator <=(FractionalNumber f1, int f2)
        {
            return (f1 - f2).Numerator <= 0;
        }

        public static FractionalNumber operator *(FractionalNumber f1, float f2)
        {
            return f1 * f2.ToFractional();
        }

        public static FractionalNumber operator *(float f1, FractionalNumber f2)
        {
            return f1.ToFractional() * f2;
        }

        public static FractionalNumber LineInterpolation(FractionalNumber first, FractionalNumber last, float coef)
        {
            return (first > last) ? coef * first + (1 - coef) * last : coef * last + (1 - coef) * first;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
