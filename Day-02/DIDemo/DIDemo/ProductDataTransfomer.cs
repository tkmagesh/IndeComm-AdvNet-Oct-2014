using System.ComponentModel.Composition;
using DIDemo.Contracts;

namespace DIDemo
{
    [Export(typeof(ProductDataTransformer))]
    public class ProductDataTransformer
    {
        private readonly IProductSource _productSource;
        private readonly IProductDestination[] _productDestinations;

        [ImportingConstructor]
       public ProductDataTransformer(IProductSource productSource, [ImportMany] IProductDestination[] productDestinations)
       {
           _productSource = productSource;
           _productDestinations = productDestinations;
       }

/*
        [Import]
        public IProductSource ProductSource { get; set; }

        [Import]
        public IProductDestination ProductDestination { get; set; }
*/
       

        public void Transform()
        {
            var products = _productSource.GetProducts();
            foreach (var productDestination in _productDestinations)
            {
                productDestination.Save(products);    
            }
            

            //ProductDestination.Save(ProductSource.GetProducts());
        }
    }
}