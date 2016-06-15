using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulExamples
{
    // В комментах вариант фильтрации для 2 шарпа, где есть предикаты и нет методов расширения
    static class LazyFilter
    {
        public static IEnumerable<T> Where<T>(this /*убрать, если нужно без метода расширения*/ IEnumerable<T> source, 
                                              /*Predicate<T>*/ Func<T, bool> predicate)
        {
            // no need to continue
            if (source == null || predicate == null)
            {
                throw new ArgumentNullException();
            }
            return WhereImpl(source, predicate);
        }

        private static IEnumerable<T> WhereImpl<T>(IEnumerable<T> source, /*Predicate<T>*/ Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        // c# 2
        public static void Method()
        {
            IEnumerable<string> phrase = new List<string>() { "declare t", "public static void", "using Stream" };
            /*Predicate<string>*/ Func<string, bool> predicate = delegate(string line) { return line.StartsWith("using"); };
            foreach (string line in phrase.Where(predicate)) /*Where(phrase, predicate)*/
            {
                Console.WriteLine(line);
            }
        }
    }
}
