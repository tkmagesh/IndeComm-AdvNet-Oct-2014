namespace CustomCollectionsDemo
{
    public class ProductComparerById : IProductComparer
    {
        public int Compare(Product left, Product right)
        {
            if (left.Id < right.Id) return -1;
            if (left.Id == right.Id) return 0;
            return 1;
        }
    }
}