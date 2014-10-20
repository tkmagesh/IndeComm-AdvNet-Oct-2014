using System;

namespace POSSystem
{

    public class SalesRegister : ISaleEventListener
    {
        private readonly IProductService _productService;
        public decimal OrderValue { private set; get; }

        public SalesRegister(IProductService productService)
        {
            _productService = productService;
        }

        public void NewSaleInitialized()
        {
            OrderValue = 0;
        }

        public void SaleEnded()
        {
            throw new NotImplementedException();
        }

        public void ProductAdded(string barcodeId, int quantity)
        {
            var productId = barcodeId.Substring(0, 6);
            var manufacturerId = barcodeId.Substring(6);
            _productService.GetInfo(productId, manufacturerId);
        }
    }

    public interface IProductService
    {
        void GetInfo(string productCode, string manufacturerCode);
    }
}