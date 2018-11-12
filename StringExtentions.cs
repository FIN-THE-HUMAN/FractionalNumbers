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
            T[] result = new T[array.Length + 1];
            Array.Copy(array, result, array.Length);
            result[result.Length - 1] = item;
            return result;
        }

        private static List<int> IndexesOf(this string str, char c)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < str.Length; i++)
                if(str[i] == c) result.Add(i);
            return result;
        }

        public static string[] Slice(this string str, char devider)
        {
            List<int> indexesOfDeviders = str.IndexesOf(devider);
            if (indexesOfDeviders.Count == 0) return new string[] { str };

            string[] result = new string[indexesOfDeviders.Count + 1];

            result[0] = str.Substring(0, indexesOfDeviders[0]);
            for (int i = 1; i < indexesOfDeviders.Count; i++)
            {
                result[i] = str.Substring(indexesOfDeviders[i - 1] + 1, indexesOfDeviders[i] - indexesOfDeviders[i - 1] - 1);
            }
            result[indexesOfDeviders.Count] = str.Substring(indexesOfDeviders[indexesOfDeviders.Count - 1] + 1, str.Length - indexesOfDeviders[indexesOfDeviders.Count - 1] - 1);

            return result;
        }

        public static bool IsEmpty(this string str)
        {
            return str.Length == 0;
        }
    }
}
