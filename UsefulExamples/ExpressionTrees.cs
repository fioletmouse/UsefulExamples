using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UsefulExamples
{
    static class ExpressionTrees
    {
        //простые примеры работы с деревьями выражений
        public static void  Method()
        {
            Expression firstArg = Expression.Constant(2);
            Expression secondArg = Expression.Constant(3);
            Expression add = Expression.Add(firstArg, secondArg);
            Console.WriteLine(add);

            Func<int> compiled = Expression.Lambda<Func<int>>(add).Compile();
            Console.WriteLine(compiled());

            Expression<Func<int>> returnNumber = () => 10;
            Func<int> compiledNumber = returnNumber.Compile();
            Console.WriteLine(compiled());
        }

        // чуть посложнее
        public static void Method2()
        {
            Expression<Func<string, string, bool>> expression = (x, y) => x.StartsWith(y);
            var compiled = expression.Compile();
            //Console.WriteLine(compiled("First", "Second"));
            //Console.WriteLine(compiled("First", "Fir"));

            // Тоже самое с рефлексией
            MethodInfo method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) }); // получаем метод

            ParameterExpression target = Expression.Parameter(typeof(string), "x");     // параметры
            ParameterExpression methodArg = Expression.Parameter(typeof(string), "y");

            Expression[] methodArgs = new[] { methodArg };  // одна из перегрузок метода принимает 1 параметр, добавляем его

            Expression call = Expression.Call(target, method, methodArgs);  // создаем выражение формата ЦелевойТип.Метод(Параметры) x.StartsWith(y)
            var lambdaParameters = new[] { target, methodArg };             // указываем параметры, которые используются в выражении
            var lambda = Expression.Lambda<Func<string, string, bool>>(call, lambdaParameters); // создаем выражение
            var compiledRefl = lambda.Compile();

            Console.WriteLine(compiled("First", "Second"));
            Console.WriteLine(compiled("First", "Fir"));
        }
    }
}
