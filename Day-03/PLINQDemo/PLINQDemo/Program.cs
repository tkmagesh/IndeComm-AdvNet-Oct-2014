using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLINQDemo
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Enumerable.Range(100,200).AsParallel().ForAll(n => Console.WriteLine("{0},{1}", n, Thread.CurrentThread.ManagedThreadId));
            var primeCount = 0;
            
            /*Parallel.For(100, 200, () => 0, (currentNumber, obj, prevResult) =>
            {
                //Console.WriteLine("currentNumber = {0}\tprevResult = {1}", currentNumber, prevResult);
                if (IsPrime(currentNumber))
                    return ++prevResult;
                return prevResult;
            }, (result) =>
            {
                primeCount += result;
               
            });
            Console.WriteLine("Current Prime count = {0}", primeCount);*/

            //Enumerable.Range(1,10)
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static bool IsPrime(int n )
        {
            for(var i=2;i<= (n/2);i++)
                if (n%i == 0) return false;
            Console.WriteLine("Prime number is = {0}", n);
            return true;
        }
    }
}
