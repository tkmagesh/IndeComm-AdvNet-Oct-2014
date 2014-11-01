using System.Collections.Generic;
using System.IO;

namespace DIDemo
{
    public class CsvProductsDestination
    {
        public void Save(List<Product> products )
        {
            var sw = new StreamWriter("products.csv");
            foreach (var product in products)
            {
                var productLine = string.Format("{0},{1},{2},{3},{4}", product.Id, product.Name, product.Cost,
                    product.Units, product.Category);
                sw.WriteLine(productLine);
            }
            sw.Close();
        }
    }
}