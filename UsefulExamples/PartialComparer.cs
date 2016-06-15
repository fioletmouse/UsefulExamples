using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulExamples
{
    class PartialComparer
    {
        public static int? Compare<T>(T first, T second)
        {
            return Compare(Comparer<T>.Default, first, second);
        }

        public static int? Compare<T>(IComparer<T> comparer, T first, T second)
        {
            int ret = comparer.Compare(first, second);
            return ret == 0 ? new int?() : ret;
        }
        public static int? ReferenceCompare<T>(T first, T second) where T : class
        {
            return first == second ? 0
            : first == null ? -1
            : second == null ? 1
            : new int?();
        }

        public static void Method()
        {
            SortingUsingComparisonC3.Product first = new SortingUsingComparisonC3.Product("first", 9.99m);
            SortingUsingComparisonC3.Product second = new SortingUsingComparisonC3.Product("first1", 9.99m);

            var tmp = ReferenceCompare(first, second) ??
                // Reverse comparison of popularity to sort descending
                    Compare(first.Price, second.Price) ??
                    Compare(first.Name, second.Name) ??
                    0;
            Console.WriteLine(tmp.ToString());
        }
    }
}
