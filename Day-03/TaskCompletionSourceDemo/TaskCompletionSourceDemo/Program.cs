using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCompletionSourceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Id = {0}", Thread.CurrentThread.ManagedThreadId);
            var t = new MyApi().GetAsyncOper();
            t.ConfigureAwait(false);
            var awaiter = t.GetAwaiter();
            
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine("Inside OnCompleted Thread id = {0}", Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine(t.Result);
            Console.ReadLine();
            //awaiter.OnCompleted();
        }
    }

    public class MyApi
    {
        public Task<int> GetAsyncOper()
        {
            var legacyObj = new LegacyClass();
        /*    Task.Factory.StartNew<int>(() =>
            {
                legacyObj.DoWork();
                legacyObj.OnCompletion += i =>
                {
                    
                };

            })*/
            var tcs = new TaskCompletionSource<int>();
            legacyObj.OnCompletion += (n) =>
            {
                tcs.SetResult(n);
                
            };
            new Thread(() =>
            {
                Console.WriteLine("Inside TaskCompletionSource Thread Id = {0}", Thread.CurrentThread.ManagedThreadId);
              legacyObj.DoWork();  
            }).Start();
            
            return tcs.Task;

        }

        
    }

    public class LegacyClass
    {
        public event Action<int> OnCompletion;
        public void DoWork()
        {
            Thread.Sleep(2000);
            OnCompletion(new Random().Next(2000));
        }
    }
}
