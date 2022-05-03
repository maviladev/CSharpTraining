using System;
using NUnit.Framework;

namespace UnitTestingLibrary
{
    [TestFixture]
    public class ClientNUnitTest
    {
        private Client _client { get; set; }

        [SetUp]
        public void SetUp()
        {
            _client = new Client();
        }

        [Test]
        public void CreateFullName_InputTwoStrings_ReturnFullName()
        {
            //arrange

            //act
            _client.CreateFullName("Marcos", "Avila");

            //assert
            Assert.That(_client.FullName, Is.EqualTo("Marcos Avila"));
            Assert.AreEqual(_client.FullName, "Marcos Avila");

            Assert.That(_client.FullName, Does.Contain("vil"));     //Case sensitive
            Assert.That(_client.FullName, Does.StartWith("Mar"));   //Case sensitive

            //Assert.That(_client.FullName, Does.Contain("vil").IgnoreCase); //Compare value
            //Assert.That(_client.FullName, Does.EndWith("ila")); 
        }


        [Test]
        public void ClientFullName_InputNoValue_ReturnsNull()
        {
            Assert.IsNull(_client.FullName);
        }

    }
}
