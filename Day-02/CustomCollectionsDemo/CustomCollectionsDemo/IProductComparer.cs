namespace CustomCollectionsDemo
{
   /* public interface IProductComparer
    {
        int Compare(Product left, Product right);
    }*/

    public interface IItemComparer<in T>
    {
        int Compare(T left, T right);
    }
}