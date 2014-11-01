using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomCollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new MyCollection<Product>();
            products.Add(new Product { Id = 4, Name = "Pen", Category = 1, Units = 10, Cost = 50 });
            products.Add(new Product { Id = 6, Name = "Hen", Category = 2, Units = 80, Cost = 30 });
            products.Add(new Product { Id = 8, Name = "Ten", Category = 1, Units = 40, Cost = 80 });
            products.Add(new Product { Id = 2, Name = "Den", Category = 2, Units = 50, Cost = 20 });
            products.Add(new Product { Id = 9, Name = "Len", Category = 1, Units = 30, Cost = 10 });
            products.Add(new Product { Id = 1, Name = "Zen", Category = 2, Units = 60, Cost = 70 });

            Console.WriteLine("Default List..");
            
            foreach(var product in products)
                Console.WriteLine(product);

            Console.WriteLine();
            Console.WriteLine("After sorting [default]");
            products.Sort(new ProductComparerById());
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine();
            Console.WriteLine("After sorting [Cost]");
            //products.Sort(CompareProductByUnits);

            /*products.Sort(delegate(Product left, Product right)
            {
                if (left.Units < right.Units) return -1;
                if (left.Units > right.Units) return 1;
                return 0;
            });*/

/*
            products.Sort((left, right) =>
            {
                if (left.Units < right.Units) return -1;
                if (left.Units > right.Units) return 1;
                return 0;
            });
*/

            /*products.Sort((left, right) =>
            {
                return left.Units - right.Units;
            });*/
            CompareItemsDelegate<Product> productComparerByCost = (left, right) => left.Units.CompareTo(right.Units);
            products.Sort(productComparerByCost);

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            Console.WriteLine("All costly products [cost > 50]");
            var costlyProducts = products.Filter(new CostlyProductCriteria(50));
            foreach (var product in costlyProducts)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();

            Console.WriteLine("Products grouped by category");
            KeySelectorDelegate<Product, int> categoryKeySelector = p => p.Category;
            var productsByCategory = products.GroupBy(categoryKeySelector);

            foreach (var groupedItem in productsByCategory)
            {
                Console.WriteLine("Category = {0}", groupedItem.Key);
                foreach (var item in groupedItem.Value)
                {
                    Console.WriteLine("\t{0}", item);
                }
            }

            Console.WriteLine();

            Console.WriteLine("Products grouped by cost");
            KeySelectorDelegate<Product, string> costBasedKeySelector = p => p.Cost > 50 ? "Costly" : "Affordable";
            var productsByCost = products.GroupBy(costBasedKeySelector);

            foreach (var groupedItem in productsByCost)
            {
                Console.WriteLine("Cost Category = {0}", groupedItem.Key);
                foreach (var item in groupedItem.Value)
                {
                    Console.WriteLine("\t{0}", item);
                }
            }
            Console.ReadLine();
        }

        /*public static int CompareProductByUnits(Product left, Product right)
        {
            if (left.Units < right.Units) return -1;
            if (left.Units > right.Units) return 1;
            return 0;
        }*/
    }
}
