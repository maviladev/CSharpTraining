using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestLibrary
{
    public class ProductXUnitTest
    {
        [Fact]
        public void GetPrice_PremiumClient_ReturnsPrice80Percent() 
        {
            Product product = new() { Price = 50 };

            // In order to use mock with this dependency is required to
            // create an interface to inherit the object then set the properties
            // var client = new Mock<IClient>();
            // client.Setup(c => c.IsPremium).Returns(true); 

            var result = product.GetPrice(new Client { IsPremium = true});
            // var result = product.getPrice(client.Object);

            Assert.Equal(40, result);
        }
    }
}
