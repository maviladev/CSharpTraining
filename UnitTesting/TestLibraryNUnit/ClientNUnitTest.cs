using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    [TestFixture]
    public class ClientNUnitTest
    {
        private Client _client;
        
        [SetUp]
        public void Setup()
        {
            _client = new();
        }

        [Test]
        [TestCase("Marcos", "Avila")]
        public void CreateFullName_InputFirstNameLastName_ReturnFullName(string firstName, string lastName) 
        {
            _client.CreateFullName(firstName, lastName);

            Assert.That(_client.ClientName, Is.EqualTo("Marcos Avila"));

            Assert.Multiple(() => {
                Assert.AreEqual(_client.ClientName, "Marcos Avila");
                Assert.That(_client.ClientName, Does.Contain("Avila"));
                Assert.That(_client.ClientName, Does.Contain("avila").IgnoreCase);
                Assert.That(_client.ClientName, Does.StartWith("Marcos"));
                Assert.That(_client.ClientName, Does.StartWith("marcos").IgnoreCase);
                Assert.That(_client.ClientName, Does.EndWith("ila"));
                Assert.That(_client.ClientName, Does.EndWith("iLa").IgnoreCase);
            });
            
        }

        [Test]
        public void ClientNameProperty_NoValue_ReturnNull() 
        {
            Assert.IsNull(_client.ClientName);
        }

        [Test]
        public void DiscountTest_DefaultClient_ReturnsDiscountInteral() 
        {
            int discount = _client.Discount;

            Assert.That(discount, Is.InRange(10, 24));
        }

        [Test]
        public void ClientNameProperty_InputFirstNameEmpty_ThrowsException() 
        {
            var exceptionDetail = Assert.Throws<ArgumentException>(() => _client.CreateFullName("", "Avila"));
            Assert.AreEqual("El nombre esta en blanco", exceptionDetail.Message);

            Assert.That(() => _client.CreateFullName("", "Avila"), 
                            Throws.ArgumentException.With.Message.EqualTo("El nombre esta en blanco"));

            // Validate against Type of exception
            Assert.Throws<ArgumentException>(() => _client.CreateFullName("", "Avila"));
            Assert.That(() => _client.CreateFullName("", "Avila"), Throws.ArgumentException);
        }

        [Test]
        public void GetClientDetail_CreateClientWithOrderTotalLessThan500_ReturnsClientBasic() 
        {
            _client.OrderTotal = 150;
            var result = _client.GetClientDetail();

            Assert.That(result, Is.TypeOf<ClientBasic>());

        }

        [Test]
        public void GetClientDetail_CreateClientWithOrderTotalMoreThan500_ReturnsClientPremium()
        {
            _client.OrderTotal = 700;
            var result = _client.GetClientDetail();

            Assert.That(result, Is.TypeOf<ClientPremium>());

        }
    }
}
