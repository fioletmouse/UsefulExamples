using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulExamples
{
    static class DelegatesdListOperation
    {
        public static void MainMethod()
        {
            Action a1 = () => Console.Write(1);
            Action a2 = () => Console.Write(2);
            Action a3 = () => Console.Write(3);

            ((a1 + a2 + a3) - (a1 + a2))(); //123-12=3
            Console.WriteLine();
            ((a1 + a2 + a3) - (a1 + a3))(); //123-13 = 123
            Console.WriteLine();
            ((a1 + a2 + a3) - (a2 + a3))(); // 123-23 = 1
            Console.WriteLine();
            ((a1 + a2 + a1) - a1)(); // 121-1 = 12
        }
    }
}
