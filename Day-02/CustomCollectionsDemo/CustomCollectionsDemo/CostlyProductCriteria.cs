namespace CustomCollectionsDemo
{
    public class CostlyProductCriteria : IFilterItemsCriteria<Product>
    {
        private readonly decimal _baseCost;

        public CostlyProductCriteria(decimal baseCost)
        {
            _baseCost = baseCost;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return product.Cost > _baseCost;
        }
    }
}