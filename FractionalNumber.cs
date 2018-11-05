using System;

namespace Encryption
{
    public class FractionalNumber
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public FractionalNumber()
        {
            Numerator = 0;
            Denominator = 1;
        }

        private static FractionalNumber Create(int numerator, int denumerator)
        {
            FractionalNumber n = new FractionalNumber();
            int gcd = Utils.GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denumerator));
            int sign = Math.Sign(denumerator);
            n.Numerator = numerator / gcd * sign;
            n.Denominator = denumerator / gcd * sign;
            return n;
        }

        public FractionalNumber(int numerator, int denumerator)
        {
            if (denumerator == 0) throw new DivideByZeroException();
            if (numerator == 0)
            {
                Numerator = 0;
                Denominator = 1;
                return;
            }

            FractionalNumber n = Create(numerator, denumerator);
            Numerator = n.Numerator;
            Denominator = n.Denominator;
        }

        public FractionalNumber(FractionalNumber n)
        {
            Numerator = n.Numerator;
            Denominator = n.Denominator;
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

            return Create(numerator, denumerator);
        }

        public static FractionalNumber operator -(FractionalNumber f1, FractionalNumber f2)
        {
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

            return Create(numerator, denumerator);
        }

        public static FractionalNumber operator *(FractionalNumber f1, FractionalNumber f2)
        {
            int numerator = f1.Numerator * f2.Numerator;
            int denumerator = f1.Denominator * f2.Denominator;
            return Create(numerator, denumerator);
        }

        public static FractionalNumber operator /(FractionalNumber f1, FractionalNumber f2)
        {
            if (f2.Numerator == 0) throw new DivideByZeroException();
            int numerator = f1.Numerator * f2.Denominator;
            int denumerator = f1.Denominator * f2.Numerator;
            return Create(numerator, denumerator);
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
            int numerator = f1.Numerator * f2;
            return Create(numerator, f1.Denominator);
        }

        public static FractionalNumber operator /(FractionalNumber f1, int f2)
        {
            if (f2 == 0) throw new DivideByZeroException();
            int denomirator = f1.Denominator * f2;
            return Create(f1.Numerator, denomirator);
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
            int numerator = f1.Numerator * f2;
            return Create(numerator, f1.Denominator);
        }

        public static FractionalNumber operator /(int f2, FractionalNumber f1)
        {
            if (f1.Numerator == 0) throw new DivideByZeroException();
            int numerator = f1.Denominator * f2;
            return Create(numerator, f1.Numerator);
        }

        public static bool operator >(FractionalNumber f1, FractionalNumber f2)
        {
            return f1.ToDouble() > f2.ToDouble();
        }

        public static bool operator <(FractionalNumber f1, FractionalNumber f2)
        {
            return f1.ToDouble() < f2.ToDouble();
        }

        public static bool operator >=(FractionalNumber f1, FractionalNumber f2)
        {
            return f1.ToDouble() >= f2.ToDouble();
        }

        public static bool operator <=(FractionalNumber f1, FractionalNumber f2)
        {
            return f1.ToDouble() <= f2.ToDouble();
        }

        public static bool operator >(int f1, FractionalNumber f2)
        {
            return f1 > f2.ToDouble();
        }

        public static bool operator <(int f1, FractionalNumber f2)
        {
            return f1 < f2.ToDouble();
        }

        public static bool operator >=(int f1, FractionalNumber f2)
        {
            return f1 >= f2.ToDouble();
        }

        public static bool operator <=(int f1, FractionalNumber f2)
        {
            return f1 <= f2.ToDouble();
        }

        public static bool operator >(FractionalNumber f1, int f2)
        {
            return f1.ToDouble() > f2;
        }

        public static bool operator <(FractionalNumber f1, int f2)
        {
            return f1.ToDouble() < f2;
        }

        public static bool operator >=(FractionalNumber f1, int f2)
        {
            return f1.ToDouble() >= f2;
        }

        public static bool operator <=(FractionalNumber f1, int f2)
        {
            return f1.ToDouble() <= f2;
        }

        public static FractionalNumber operator +(FractionalNumber f1, float f2)
        {
            return f1 + f2.ToFractional();
        }

        public static FractionalNumber operator +(float f1, FractionalNumber f2)
        {
            return f1.ToFractional() + f2;
        }

        public static FractionalNumber operator -(FractionalNumber f1, float f2)
        {
            return f1 - f2.ToFractional();
        }

        public static FractionalNumber operator -(float f1, FractionalNumber f2)
        {
            return f1.ToFractional() - f2;
        }

        public static FractionalNumber operator *(FractionalNumber f1, float f2)
        {
            return f1 * f2.ToFractional();
        }

        public static FractionalNumber operator *(float f1, FractionalNumber f2)
        {
            return f1.ToFractional() * f2;
        }

        public static FractionalNumber operator /(FractionalNumber f1, float f2)
        {
            return f1 / f2.ToFractional();
        }

        public static FractionalNumber operator /(float f1, FractionalNumber f2)
        {
            return f1.ToFractional() / f2;
        }

        public static FractionalNumber operator +(FractionalNumber f1, double f2)
        {
            return f1 + f2.ToFractional();
        }

        public static FractionalNumber operator +(double f1, FractionalNumber f2)
        {
            return f1.ToFractional() + f2;
        }

        public static FractionalNumber operator -(FractionalNumber f1, double f2)
        {
            return f1 - f2.ToFractional();
        }

        public static FractionalNumber operator -(double f1, FractionalNumber f2)
        {
            return f1.ToFractional() - f2;
        }

        public static FractionalNumber operator *(FractionalNumber f1, double f2)
        {
            return f1 * f2.ToFractional();
        }

        public static FractionalNumber operator *(double f1, FractionalNumber f2)
        {
            return f1.ToFractional() * f2;
        }

        public static FractionalNumber operator /(FractionalNumber f1, double f2)
        {
            return f1 / f2.ToFractional();
        }

        public static FractionalNumber operator /(double f1, FractionalNumber f2)
        {
            return f1.ToFractional() / f2;
        }

        public static bool operator >(float f1, FractionalNumber f2)
        {
            return f1 > f2.ToDouble();
        }

        public static bool operator <(float f1, FractionalNumber f2)
        {
            return f1 < f2.ToDouble();
        }

        public static bool operator >=(float f1, FractionalNumber f2)
        {
            return f1 >= f2.ToDouble();
        }

        public static bool operator <=(float f1, FractionalNumber f2)
        {
            return f1 <= f2.ToDouble();
        }

        public static bool operator >(FractionalNumber f1, float f2)
        {
            return f1.ToDouble() > f2;
        }

        public static bool operator <(FractionalNumber f1, float f2)
        {
            return f1.ToDouble() < f2;
        }

        public static bool operator >=(FractionalNumber f1, float f2)
        {
            return f1.ToDouble() >= f2;
        }

        public static bool operator <=(FractionalNumber f1, float f2)
        {
            return f1.ToDouble() <= f2;
        }

        public static bool operator >(double f1, FractionalNumber f2)
        {
            return f1 > f2.ToDouble();
        }

        public static bool operator <(double f1, FractionalNumber f2)
        {
            return f1 < f2.ToDouble();
        }

        public static bool operator >=(double f1, FractionalNumber f2)
        {
            return f1 >= f2.ToDouble();
        }

        public static bool operator <=(double f1, FractionalNumber f2)
        {
            return f1 <= f2.ToDouble();
        }

        public static bool operator >(FractionalNumber f1, double f2)
        {
            return f1.ToDouble() > f2;
        }

        public static bool operator <(FractionalNumber f1, double f2)
        {
            return f1.ToDouble() < f2;
        }

        public static bool operator >=(FractionalNumber f1, double f2)
        {
            return f1.ToDouble() >= f2;
        }

        public static bool operator <=(FractionalNumber f1, double f2)
        {
            return f1.ToDouble() <= f2;
        }

        public static FractionalNumber LineInterpolation(FractionalNumber first, FractionalNumber last, float coef)
        {
            return (first > last) ? coef * first + (1 - coef) * last : coef * last + (1 - coef) * first;
        }

        public static FractionalNumber LineInterpolation(FractionalNumber first, FractionalNumber last, double coef)
        {
            return (first > last) ? coef * first + (1 - coef) * last : coef * last + (1 - coef) * first;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
