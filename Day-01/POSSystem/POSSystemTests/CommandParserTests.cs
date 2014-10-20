using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using POSSystem;

namespace POSSystemTests
{
    [TestClass]
    public class CommandParserTests
    {
        [TestMethod]
        public void Triggers_NewSale_Event_On_SaleRegister_For_NewSale_Command()
        {
            //Arrange
            var saleListenerMock = new Mock<ISaleEventListener>();
            var commandParser = new CommandParser(saleListenerMock.Object);
            

            //Act
            commandParser.Parse("Command:NewSale");

            //Assert
            //NewSale Method on the SaleRegister should have been called
            saleListenerMock.Verify(se => se.NewSaleInitialized(), Times.Once);
        }

        [TestMethod]
        public void Triggers_EndSale_Event_On_SaleRegister_For_EndSale_Command()
        {
            //Arrange
            var saleListenerMock = new Mock<ISaleEventListener>();
            var commandParser = new CommandParser(saleListenerMock.Object);


            //Act
            commandParser.Parse("Command:EndSale");

            //Assert
            //NewSale Method on the SaleRegister should have been called
            saleListenerMock.Verify(se => se.SaleEnded(), Times.Once);
        }

        [TestMethod]
        public void Triggers_ProductAdded_Event_On_SaleRegister_For_Input_Command()
        {
            //Arrange
            var saleListenerMock = new Mock<ISaleEventListener>();
            var commandParser = new CommandParser(saleListenerMock.Object);


            //Act
            commandParser.Parse("Input:Barcode=100008888559,Quantity =1");

            //Assert
            //NewSale Method on the SaleRegister should have been called
            saleListenerMock.Verify(se => se.ProductAdded("100008888559", 1), Times.Once);
        }
    }
}
