using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumber(this string input)
        {
            int testOut = 0;
            return int.TryParse(input, out testOut);
        }

        public static bool IsArrayOfNumbers(this string input)
        {
            int testOut = 0;
            input = input.Replace(" ", "");
            string[] split = input.Split(',');
            if (split.Length <= 1)
            {
                return false;
            }
            for (int i = 0; i < split.Length; i++)
            {
                if (!int.TryParse(input, out testOut))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsNumber(this string input, out int output)
        {
            if (input.IsNumber())
            {
                output = int.Parse(input);
                return true;
            }
            else
            {
                output = 0;
                return false;
            }
        }

    }
}
