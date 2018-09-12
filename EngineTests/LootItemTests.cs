using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Tests
{
    [TestClass()]
    public class LootItemTests
    {
        [TestMethod()]
        public void LootItemTest()
        {
            
            Item details = World.ItemById(9);
            int dropPercentage = 100;
            bool isDefaultItem = false;
            LootItem zbierajka = new LootItem(details, dropPercentage,isDefaultItem);
            //List<LootItem> listaZbierajek = new List<LootItem>();
            string expectedName = "Spider silk";
            string actualName = zbierajka.Details.Name;
            Assert.AreEqual(expectedName,actualName,
                "Item's name is different than expected");
            
            Assert.AreEqual(100, zbierajka.DropPercentage, "'Drop percentage' is different than assigned.");
            Assert.IsFalse(zbierajka.IsDefaultItem, 
                "This item should not been default, yet it is recognized as one.");
        }
    }
}