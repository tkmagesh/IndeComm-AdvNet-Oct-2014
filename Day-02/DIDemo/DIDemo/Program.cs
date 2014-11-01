using System;
using System.Linq;
using System.Text;

namespace DIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataTransformer = new ProductDataTransfomer();
            dataTransformer.Transform();
            Console.WriteLine("Data transformed");
            Console.ReadLine();
        }
    }
}
