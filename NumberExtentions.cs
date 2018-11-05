using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Encryption
{
    public static class NumberExtentions
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        public static bool IsOdd(this int number)
        {
            return number % 2 == 1;
        }

        public static string ToAlgebraic(this Complex c)
        {
            char sign = c.Imaginary > 0 ? '+' : '-';
            return $"{c.Real} {sign} {c.Imaginary}*i ";
        }

        public static int Concatinate(this int i, int j)
        {
            return i * (int)Math.Pow(10, (int)Math.Ceiling(Math.Log10(j))) + j;
        }

        public static int ConcatinateS(this int i, int j)
        {
            return Convert.ToInt32(i.ToString() + j.ToString());
        }

        public static FractionalNumber ToFractional(this float f)
        {
            string number = f.ToString();
            var wholeAndReduce = number.Slice(',');

            if(wholeAndReduce[wholeAndReduce.Length - 1].IsEmpty())
            {
                return FractionalNumber.GetInstance((int)f, 1);
            }
            else
            {
                return FractionalNumber.GetInstance(
                    Convert.ToInt32(wholeAndReduce[0] + wholeAndReduce[1]), 
                    (int)Math.Pow(10, wholeAndReduce[1].Length)
                );
            }
        }

        public static FractionalNumber ToFractional(this double f)
        {
            string number = f.ToString();
            var wholeAndReduce = number.Slice(',');

            if (wholeAndReduce[wholeAndReduce.Length - 1].IsEmpty())
            {
                return FractionalNumber.GetInstance((int)f, 1);
            }
            else
            {
                return FractionalNumber.GetInstance(
                    Convert.ToInt32(wholeAndReduce[0] + wholeAndReduce[1]),
                    (int)Math.Pow(10, wholeAndReduce[1].Length)
                );
            }
        }
    }
}
