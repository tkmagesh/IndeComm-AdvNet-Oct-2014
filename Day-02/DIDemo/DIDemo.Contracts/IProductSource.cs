using System.Collections.Generic;

namespace DIDemo.Contracts
{
    public interface IProductSource
    {
        List<Product> GetProducts();
    }
}