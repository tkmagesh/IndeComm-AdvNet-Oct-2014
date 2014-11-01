namespace CustomCollectionsDemo
{
    public class ProductComparerByCost : IItemComparer<Product>
    {
        public int Compare(Product left, Product right)
        {
            if (left.Cost < right.Cost) return -1;
            if (left.Cost == right.Cost) return 0;
            return 1;
        }
    }
}