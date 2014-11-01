namespace CustomCollectionsDemo
{
    //public delegate int CompareProductsDelegate(Product left, Product right);

    public delegate int CompareItemsDelegate<in T>(T left, T right);
}