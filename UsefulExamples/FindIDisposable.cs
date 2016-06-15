using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UsefulExamples
{
    static class FindIDisposable
    {
        static public void Method1()
        {
            var disposableTypes = from a in AppDomain.CurrentDomain.GetAssemblies()
                                  from t in a.GetTypes()
                                  where typeof(IDisposable).IsAssignableFrom(t)
                                  select t;
            foreach (var item in disposableTypes)
            {
                Console.WriteLine(item.FullName);
            }
        }
    }
}
