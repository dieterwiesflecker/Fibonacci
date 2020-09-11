using System;
using System.Collections;
using System.Collections.Generic;
using static Fibonacci.Math;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Fibonacci
{
    public static class MyExtension
    {
        public static void MyForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (TSource item in source)
            {
                action(item);
            }
        }

        //public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        //{
        //    foreach(var x in source)
        //    {
        //        if
        //    }
        //}

        public static string ToMd5(this string x)
        {
            return x;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
 

            Console.WriteLine("Hello Fibonacci!");
            foreach (int i in Math.Fibonacci(30))
            {
                Console.WriteLine("{0} ", i);
            }
             
            var x = Math.Fibonacci(20);

            var q1 = from s in x
                     where s < 50
                     select new { x };

            var filter2 = x.Where(x => x < 50);

            Expression<Func<int, bool>> under50 = x => x < 50;

            var u50 = x.Where(under50.Compile());

            //var xyz = x.Where(x => filter2);

            var xxx = q1.ToString();

            u50.MyForEach<int>(x => Console.WriteLine(x));

             Console.ReadKey();
        }

        static void Main2(string[] args)
        {
            CityCollection myColl = new CityCollection();
            // Ausgabe
            foreach (string s in myColl)
            {
                Console.WriteLine(s);
            }
            // Ausgabe in umgekehrter Reihenfolge
 
        }

    }

    public static class Math
    {
        public static IEnumerable<int> Fibonacci(int length)
        {
            int temp = 0;
            int temp1 = 1;
            for (int i = 0; i < length; i++)
            {
                if (i < 2)
                    yield return i;
                else
                {
                    int n = temp + temp1;
                    yield return n;
                    temp = temp1;
                    temp1 = n; 
                }
            }
        }

        public class CityCollection : IEnumerable<string>
        {
            private string[] cities =
            { "Bern", "Basel", "Zürich", "Rapperswil", "Genf" };

            public IEnumerator<string> GetEnumerator()
            {
                return ((IEnumerable<string>)cities).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return cities.GetEnumerator();
            }

            //public IEnumerable<string> GetEnumerable()
            //{
            //    foreach (string n in cities)
            //    {
            //        yield return n;
            //    }
            //}
        }

    }
}
