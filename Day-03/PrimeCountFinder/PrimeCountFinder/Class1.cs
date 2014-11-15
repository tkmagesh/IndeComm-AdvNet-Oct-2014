using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PrimeCountFinder
{
    class Class1
    {
        private volatile int count;
        private void Dummy()
        {
            int start = 100000;
            int end = 125000;
            Task<int> t1 = GetFindPrimeTask(start, end);

            start = 125000;
            end = 150000;

            var t2 = GetFindPrimeTask(start, end);

            start = 150000;
            end = 175000;

            var t3 = GetFindPrimeTask(start, end);

            start = 175000;
            end = 200000;

            var t4 = GetFindPrimeTask(start, end);

            MessageBox.Show("Work started");

            Task.WaitAll(t1, t2, t3, t4);

            //int count = 0;

            t1.ContinueWith(antecendent =>
            {
                //Interlocked.Add(ref count, antecendent.Result);
                count += antecendent.Result;
            });

            t2.ContinueWith(antecendent =>
            {
                count += antecendent.Result;
            });
            t3.ContinueWith(antecendent =>
            {
                count += antecendent.Result;
            });
            t4.ContinueWith(antecendent =>
            {
                count += antecendent.Result;
            });

            MessageBox.Show(count.ToString());
        }

        private void UpdateCount(int result)
        {
            var obj = new object();
            lock (obj)
            {
                count += result;
            }
        }

        private Task<int> GetFindPrimeTask(int start, int end)
        {
            Task<int> t1 = Task.Factory.StartNew<int>((obj) =>
            {
                var result = GetPrimeCount(obj);
                return result;
            }, new PrimeFindData { Start = start, End = end });

            return t1;
        }

        private int GetPrimeCount(object data)
        {
            var primeFindData = (PrimeFindData)data;
            var primeCount = 0;
            for (var i = primeFindData.Start; i <= primeFindData.End; i++)
            {
                if (isPrime(i))
                    primeCount++;
            }
            return primeCount;
        }

        private bool isPrime(int n)
        {
            for (var i = 2; i <= (n / 2); i++)
                if (n % i == 0) return false;
            return true;
        }
    }
}
