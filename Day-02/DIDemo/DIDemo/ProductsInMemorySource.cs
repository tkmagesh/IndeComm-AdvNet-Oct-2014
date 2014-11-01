using System.Collections.Generic;
using System.ComponentModel.Composition;
using DIDemo.Contracts;

namespace DIDemo
{
    [Export(typeof(IProductSource))]
    public class ProductsInMemorySource : IProductSource
    {
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            products.Add(new Product { Id = 4, Name = "Pen", Category = 1, Units = 10, Cost = 50 });
            products.Add(new Product { Id = 6, Name = "Hen", Category = 2, Units = 80, Cost = 30 });
            products.Add(new Product { Id = 8, Name = "Ten", Category = 1, Units = 40, Cost = 80 });
            products.Add(new Product { Id = 2, Name = "Den", Category = 2, Units = 50, Cost = 20 });
            products.Add(new Product { Id = 9, Name = "Len", Category = 1, Units = 30, Cost = 10 });
            products.Add(new Product { Id = 1, Name = "Zen", Category = 2, Units = 60, Cost = 70 });
            return products;
        } 
    }
}