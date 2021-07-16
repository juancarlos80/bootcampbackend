using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    static class MyLinqExtensions
    {


        public static IEnumerable<T> ProcessSequence<T>(this IEnumerable<T> sequence)
        {

            return sequence;
        }

        public static int? Median(this IEnumerable<int?> sequence)
        {
            var ordered = sequence.OrderBy(item => item);
            int middlePosition = ordered.Count() / 2;
            return ordered.ElementAt(middlePosition);
        }

        public static int? Median<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            return sequence.Select(selector).Median();
        }
        

        public static Dictionary<int?, int> CountAndGroup(this IEnumerable<int?> sequence)
        {
            Dictionary<int?, int> ocurrences = new();
            foreach (int? item in sequence)
            {
                if (ocurrences.ContainsKey(item))
                {
                    ocurrences[item]++;
                }
                else
                {
                    ocurrences[item] = 1;
                }
            }

            return ocurrences;
        }


        public static int? Mode<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            return sequence
                .Select(selector)
                .CountAndGroup()
                .OrderByDescending(order => order.Value)
                .ElementAt(0).Key;

        }

        public static int? UnMode<T>(this IEnumerable<T> sequence, Func<T, int?> selector)
        {
            return sequence
                .Select(selector)
                .CountAndGroup()
                .OrderBy(or => or.Value)
                .ElementAt(0).Key;
        }

    }
}
