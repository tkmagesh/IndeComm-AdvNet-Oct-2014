using System.Collections.Generic;

namespace DIDemo.Contracts
{
    public interface IProductDestination
    {
        void Save(List<Product> products );
    }
}