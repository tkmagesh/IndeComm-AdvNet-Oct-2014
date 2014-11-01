namespace DIDemo
{
    public class ProductDataTransfomer
    {
        public void Transform()
        {
            var source = new ProductsInMemorySource();
            var destination = new CsvProductsDestination();
            destination.Save(source.GetProducts());
        }
    }
}