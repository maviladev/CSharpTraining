using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestLibrary
{
    public class ClientXUnitTest
    {
        private Client _client;
        public ClientXUnitTest()
        {
            _client = new();
        }

        [Theory]
        [InlineData("Marcos", "Avila")]
        public void CreateFullName_InputFirstNameLastName_ReturnFullName(string firstName, string lastName)
        {
            _client.CreateFullName(firstName, lastName);
           
            Assert.Equal("Marcos Avila", _client.ClientName);
            Assert.Contains("Avila", _client.ClientName);
            Assert.StartsWith("Marcos", _client.ClientName);
            Assert.EndsWith("ila", _client.ClientName);
            
        }

        [Fact]
        public void ClientNameProperty_NoValue_ReturnNull()
        {
            Assert.Null(_client.ClientName);
        }

        [Fact]
        public void DiscountTest_DefaultClient_ReturnsDiscountInteral()
        {
            int discount = _client.Discount;

            Assert.InRange(discount, 10, 24);
        }

        [Fact]
        public void ClientNameProperty_InputFirstNameEmpty_ThrowsException()
        {
            var exceptionDetail = Assert.Throws<ArgumentException>(() => _client.CreateFullName("", "Avila"));
            Assert.Equal("El nombre esta en blanco", exceptionDetail.Message);

            // Validate against Type of exception
            Assert.Throws<ArgumentException>(() => _client.CreateFullName("", "Avila"));
        }

        [Fact]
        public void GetClientDetail_CreateClientWithOrderTotalLessThan500_ReturnsClientBasic()
        {
            _client.OrderTotal = 150;
            var result = _client.GetClientDetail();

            Assert.IsType<ClientBasic>(result);

        }

        [Fact]
        public void GetClientDetail_CreateClientWithOrderTotalMoreThan500_ReturnsClientPremium()
        {
            _client.OrderTotal = 700;
            var result = _client.GetClientDetail();

            Assert.IsType<ClientPremium>(result);

        }
    }
}
