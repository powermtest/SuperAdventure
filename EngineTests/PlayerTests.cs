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
    public class PlayerTests
    {
        [TestMethod()]
        public void PlayerCreateTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            Player expectedPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            
            Assert.IsTrue(expectedPlayer.Gold.Equals(99)
                          && expectedPlayer.CurrentHitPoints.Equals(100)
                          && expectedPlayer.MaximumHitPoints.Equals(100)
                          && expectedPlayer.ExperiencePoints.Equals(500)
                          && expectedPlayer.Level.Equals(60));
        }

        [TestMethod()]
        public void HasRequiredItemToEnterThisLocationItemRequiredToEnterIsNullTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            Location location = World.LocationById(1);
            var name = location.Name;
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            Assert.IsTrue(createPlayer.HasRequiredItemToEnterThisLocation(location));
        }

        [TestMethod()]
        public void HasRequiredItemToEnterThisLocationItemValidLocationGuardPostTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            Location location = World.LocationById(3);
            
            //var name = location.Name;
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.AddItemToInventory(World.ItemById(10));
            //var nazwa = World.ItemById(10).Name;
            Assert.IsTrue(createPlayer.HasRequiredItemToEnterThisLocation(location));
        }

        [TestMethod()]
        public void HasRequiredItemToEnterThisLocationItemInvalidLocationGuardPostTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            Location location = World.LocationById(3);

            //var name = location.Name;
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.AddItemToInventory(World.ItemById(1));
            //var nazwa = World.ItemById(10).Name;
            Assert.IsFalse(createPlayer.HasRequiredItemToEnterThisLocation(location));
        }

        [TestMethod()]
        public void HasThisQuestTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CompletedThisQuestTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void HasAllQuestCompletionItemsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveQuestCompletionItemsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddItemToInventoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MarkQuestCompletedTest()
        {
            Assert.Fail();
        }
    }
}