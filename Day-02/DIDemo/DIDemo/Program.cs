using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.ComponentModel.Composition;
using DIDemo.Contracts;


namespace DIDemo
{
    class Program
    {
        [Import]
        public ProductDataTransformer DataTransformer { get; set; }

        public void Run()
        {
            DataTransformer.Transform();
        }

        static void Main(string[] args)
        {
            var directoryCatalog = new DirectoryCatalog("transformers");
            var assemblyCatalog = new AssemblyCatalog(typeof(Program).Assembly);
            var aggregateCatalog = new AggregateCatalog(assemblyCatalog, directoryCatalog);
            var compositionContainer = new CompositionContainer(aggregateCatalog);

            var p = new Program();
            compositionContainer.ComposeParts(p);
            p.Run();
            Console.WriteLine("Job Done!!");
            Console.ReadLine();
        }
    }

    public class MyLazy<T>
    {
        private readonly Func<T> _initializer;

        public MyLazy(Func<T> initializer )
        {
            _initializer = initializer;
        }

        private T _value;
        public bool IsInitialized { private set; get; }
        public T Value
        {
            get
            {
                if (!IsInitialized)
                {
                    _value = _initializer();
                    IsInitialized = true;
                }
                return _value;
            }
        }
    }

}
