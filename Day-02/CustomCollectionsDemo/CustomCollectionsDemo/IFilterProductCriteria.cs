namespace CustomCollectionsDemo
{
    /*public interface IFilterProductCriteria
    {
        bool IsSatisfiedBy(Product product);
    }*/

    public interface IFilterItemsCriteria<T>
    {
        bool IsSatisfiedBy(T item);
    }
}