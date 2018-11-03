using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public static class StringExtentions
    {
        public static string[] Slice(this string str, char devider)
        {
            int start = 0;
            List<string> result = new List<string>();
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] == devider)
                {
                    result.Add(str.Substring(start, i - start));
                    start = i + 1;
                }
            }

            if (start == 0)
            {
                result.Add(str);
            }
            else
            {
                result.Add(str.Substring(start, str.Length - start));
            }

            return result.ToArray();
        }

        public static bool IsEmpty(this string str)
        {
            return str.Length == 0;
        }
    }
}
