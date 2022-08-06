using System;
using MTechSystems.Entities;
using NUnit.Framework;

namespace MTechSystems
{
    [TestFixture]
    public class Item_NUnit_Test
    {
        private Item _item;

        [SetUp]
        public void Setup()
        {
            _item = new Item();
        }

        [Test]
        public void ItemNameProperty_NoValue_ReturnsNull()
        {
            Assert.IsNull(_item.Name);     
        } 
    }
}

