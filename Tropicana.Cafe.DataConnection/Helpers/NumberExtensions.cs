using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tropicana.Cafe.Main.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsBetween(this int input, int start, int end)
        {
            return (input >= start && input <= end);
        }
        public static bool IsBetweenExcusive(this int input, int start, int end)
        {
            return (input > start && input < end);
        }
        public static bool IsBetweenTailInclusive(this int input, int start, int end)
        {
            return (input > start && input <= end);
        }
        public static bool IsBetweenHeadInclusive(this int input, int start, int end)
        {
            return (input >= start && input < end);
        }
        public static bool IsIn(this int test, int[] array)
        {
            return (array.Contains(test));
        }
        public static bool IsGreaterThan(this int current, int test)
        {
            return (current > test);
        }
        public static bool IsLessThan(this int current, int test)
        {
            return (current < test);
        }
    }
}
