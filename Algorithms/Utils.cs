using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Utils
    {
        public static T MinBy<T>(ICollection<T> values, Comparer<T> comparer)
        {
            return MinBy(values, comparer, default(T));
        }

        public static T MinBy<T>(ICollection<T> values, Comparer<T> comparer, T defaultValue)
        {
            if (values.Count == 0)
            {
                throw new ArgumentException("Must have at least one value");
            }
            T min = defaultValue;
            foreach (T value in values)
            {
                if (min == null || min.Equals(defaultValue) || comparer.Compare(min, value) > 0)
                {
                    min = value;
                }
            }
            return min;
        }
    }
}
