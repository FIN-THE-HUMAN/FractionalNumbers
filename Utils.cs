using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class Utils
    {
        public static int GreatestCommonDivisor(int a, int b)
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

        public static int Cells(uint i)
        {
            return (i == 0) ? 1 : (int)Math.Ceiling(Math.Log10(i + 0.5));
        }
    }
}
