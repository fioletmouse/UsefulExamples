using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulExamples
{
    static class capturedDelegate
    {
        public delegate void TestDelegate();
        public static void Method()
        {
            string captured = "before x is created";
            
            TestDelegate x = delegate()
            {
                Console.WriteLine(captured);
                captured = "changed by delegate";
            };

            captured = "directly before x is invoked";
            x();

            Console.WriteLine(captured);
            captured = "before second invocation";
            x();
        }
    }
}
