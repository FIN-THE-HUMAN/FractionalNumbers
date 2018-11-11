using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public static class StringExtentions
    {
        /// <summary>
        /// Returns array contains all original array elements and item element
        /// </summary>
        private static T[] ArrayWith<T>(this T[] array, T item)
        {
            T[] buffer = new T[array.Length];
            Array.Copy(array, buffer, array.Length);
            T[] result = new T[buffer.Length + 1];
            Array.Copy(buffer, result, buffer.Length);
            result[result.Length - 1] = item;
            return result;
        }

        public static string[] Slice(this string str, char devider)
        {
            int start = 0;
            string[] result = new string[0];
            string[] buffer = new string[0];
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == devider)
                {
                    result = result.ArrayWith(str.Substring(start, i - start));
                    start = i + 1;
                }
            }

            if (start == 0)
            {
                result = new string[1];
                result[0] = str;
            }
            else
            {
                result = result.ArrayWith(str.Substring(start, str.Length - start));
            }

            return result;
        }

        public static bool IsEmpty(this string str)
        {
            return str.Length == 0;
        }
    }
}
