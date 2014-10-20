using System;
using System.Diagnostics;
using GreetingApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GreetingAppTests
{
    /*public class TimeServiceForMorning : ITimeService
    {
        public DateTime GetCurentDateTime()
        {
            return new DateTime(2014,10,20,9,0,0);
        }
    }

    public class TimeServiceForEvening : ITimeService
    {
        public DateTime GetCurentDateTime()
        {
            return new DateTime(2014, 10, 20, 17, 0, 0);
        }
    }*/

    [TestClass]
    public class GreeterTests
    {
        [TestMethod]
        public void When_Greeted_Before_12_Greets_Good_Day()
        {
            //Arrange
            var timeServiceMock = new Mock<ITimeService>();
            timeServiceMock.Setup(o => o.GetCurentDateTime()).Returns(new DateTime(2014, 10, 20, 9, 0, 0));

            var emailServiceMock = new Mock<IEmailService>();

            var greeter = new Greeter(timeServiceMock.Object, emailServiceMock.Object);
            var name = "Magesh";
            var expectedResult = "Good Day Magesh";

            //Act
            var greetMsg = greeter.Greet(name);

            //Assert
            Assert.AreEqual(expectedResult,greetMsg);
        }


        [TestMethod]
        public void When_Greeted_After_12_Greets_Good_Evening()
        {
            //Arrange
            var timeServiceMock = new Mock<ITimeService>();
            timeServiceMock.Setup(o => o.GetCurentDateTime()).Returns(new DateTime(2014, 10, 20, 19, 0, 0));

            var emailServiceMock = new Mock<IEmailService>();
            var greeter = new Greeter(timeServiceMock.Object, emailServiceMock.Object);
            var name = "Magesh";
            var expectedResult = "Good Evening Magesh";

            //Act
            var greetMsg = greeter.Greet(name);

            //Assert
            Assert.AreEqual(expectedResult, greetMsg);
            emailServiceMock.Verify(es => es.Send(name), Times.Once);
        }
    }
}
