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

        public static uint ToUint(this int i)
        {
            return (uint)Math.Abs(i);
        } 

        public static uint Concatinate(this uint i, uint j)
        {
            return i * (uint)Math.Pow(10, Utils.Cells(j)) + j;
        }

        public static uint ConcatinateS(this uint i, uint j)
        {
            return Convert.ToUInt32(i.ToString() + j.ToString());
        }

        public static FractionalNumber ToFractional(this float f)
        {
            string number = f.ToString();
            var wholeAndReduce = number.Split(',');

            if(wholeAndReduce.Length < 2)
            {
                return new FractionalNumber((int)f, 1);
            }
            else
            {
                return new FractionalNumber(
                    Convert.ToInt32(wholeAndReduce[0] + wholeAndReduce[1]), 
                    (int)Math.Pow(10, wholeAndReduce[1].Length)
                );
            }
        }

        public static FractionalNumber ToFractional(this double f)
        {
            string number = f.ToString();
            var wholeAndReduce = number.Split(',');

            if (wholeAndReduce.Length < 2)
            {
                return new FractionalNumber((int)f, 1);
            }
            else
            {
                return new FractionalNumber(
                    Convert.ToInt32(wholeAndReduce[0] + wholeAndReduce[1]),
                    (int)Math.Pow(10, wholeAndReduce[1].Length)
                );
            }
        }
    }
}
