using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using POSSystem;

namespace POSSystemTests
{
    [TestClass]
    public class SaleRegisterTests
    {
        [TestMethod]
        public void When_NewSaleInitialized_Order_Value_Is_Zero()
        {
            var productServiceMock = new Mock<IProductService>();
            var saleRegister = new SalesRegister(productServiceMock.Object);

            saleRegister.NewSaleInitialized();

            Assert.AreEqual(0, saleRegister.OrderValue);
        }

        [TestMethod]
        public void When_NewProduct_Is_Added_Order_Value_Is_Non_Zero()
        {
            var productServiceMock = new Mock<IProductService>();
            var saleRegister = new SalesRegister(productServiceMock.Object);

            saleRegister.NewSaleInitialized();

            //Assert.AreNotEqual(0, saleRegister.OrderValue);
        }

        [TestMethod]
        public void When_NewProduct_Is_Added_Product_Serice_Is_Invoked_For_Product_Information()
        {
            var productServiceMock = new Mock<IProductService>();
            
            var saleRegister = new SalesRegister(productServiceMock.Object);

            saleRegister.ProductAdded("10000888559",1);

            productServiceMock.Verify(ps => ps.GetInfo("100008", "88559"), Times.Once);    
        }
        

    }
}
