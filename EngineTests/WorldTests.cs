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
    public class WorldTests
    {
        #region ItemById
        [TestMethod()]
        public void ItemByIdNameTest()
        {
            
            Item itemByIdExpected = World.ItemById(1);
            
            Assert.AreEqual("Rusty sword", itemByIdExpected.Name);
        }

        [TestMethod()]
        public void ItemByIdIdTest()
        {

            Item itemByIdExpected = World.ItemById(1);

            Assert.AreEqual(1, itemByIdExpected.Id);
        }

        [TestMethod()]
        public void ItemByIdNamePluralTest()
        {

            Item itemByIdExpected = World.ItemById(1);

            Assert.AreEqual("Rusty swords", itemByIdExpected.NamePlural);
        }

        [TestMethod()]
        public void ItemByIdIdTooHighTest()
        {

            Item itemByIdTooHigh = World.ItemById(100);

            Assert.IsNull(itemByIdTooHigh);
        }
        //************

        #endregion

        //***********************
        #region MonsterById
        [TestMethod()]
        public void MonsterByIdNameTest()
        {
            Monster actualMonsterById = World.MonsterById(1);

            Assert.AreEqual("Rat",actualMonsterById.Name);
        }

        [TestMethod()]
        public void MonsterByIdLootTableCountTest()
        {
            Monster actualMonsterById = World.MonsterById(1);

            Assert.AreEqual(2, actualMonsterById.LootTable.Count);
        }

        [TestMethod()]
        public void MonsterByIdIdTest()
        {
            Monster actualMonsterById = World.MonsterById(1);

            Assert.AreEqual(1, actualMonsterById.Id);
        }

        [TestMethod()]
        public void MonsterByIdMaximumDamageTest()
        {
            Monster actualMonsterById = World.MonsterById(1);

            Assert.AreEqual(5, actualMonsterById.MaximumDamage);
        }

        [TestMethod()]
        public void MonsterByIdRewardExperiencePointsTest()
        {
            Monster actualMonsterById = World.MonsterById(1);

            Assert.AreEqual(3, actualMonsterById.RewardExperiencePoints);
        }

        [TestMethod()]
        public void MonsterByIdRewardGoldTest()
        {
            Monster actualMonsterById = World.MonsterById(1);

            Assert.AreEqual(10, actualMonsterById.RewardGold);
        }

        [TestMethod()]
        public void MonsterByIdCurrentHitPointsTest()
        {
            Monster actualMonsterById = World.MonsterById(1);

            Assert.AreEqual(3, actualMonsterById.CurrentHitPoints);
        }

        [TestMethod()]
        public void MonsterByIdMaximumHitPointsTest()
        {
            Monster actualMonsterById = World.MonsterById(1);

            Assert.AreEqual(3, actualMonsterById.MaximumHitPoints);
        }

        [TestMethod()]
        public void MonsterByIdIdTooHighTest()
        {
            Monster actualMonsterById = World.MonsterById(100);

            Assert.IsNull(actualMonsterById);
        }
        //***********************
        #endregion  

        #region QuestByIdName
        //************
        [TestMethod()]
        public void QuestByIdNameTest()
        {
            
            Quest actualQuestById = World.QuestById(1);
            Assert.AreEqual("Clear the alchemist's garden", actualQuestById.Name);
        }

        [TestMethod()]
        public void QuestByIdRewardExperiencePointsTest()
        {

            Quest actualQuestById = World.QuestById(1);
            Assert.AreEqual(20,actualQuestById.RewardExperiencePoints);
        }

        [TestMethod()]
        public void QuestByIdDescriptionTest()
        {

            Quest actualQuestById = World.QuestById(1);
            Assert.AreEqual("Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a healing potion and 10 gold pieces.", actualQuestById.Description);
        }

        [TestMethod()]
        public void QuestByIdIdTest()
        {

            Quest actualQuestById = World.QuestById(1);
            Assert.AreEqual(1, actualQuestById.Id);
        }

        [TestMethod()]
        public void QuestByIdRewardGoldTest()
        {

            Quest actualQuestById = World.QuestById(1);
            Assert.AreEqual(10, actualQuestById.RewardGold);
        }

        [TestMethod()]
        public void QuestByIdIdTooHighTest()
        {

            Quest actualQuestById = World.QuestById(100);
            Assert.IsNull(actualQuestById);
        }
        //******************
        #endregion

        #region LocationById
        [TestMethod()]
        public void LocationByIdIdTest()
        {
            Location actualLocationById = World.LocationById(1);
            Assert.AreEqual(1, actualLocationById.Id);
        }

        [TestMethod()]
        public void LocationByIdNameTest()
        {
            Location actualLocationById = World.LocationById(1);
            Assert.AreEqual("Home", actualLocationById.Name);
        }

        [TestMethod()]
        public void LocationByIdDescriptionTest()
        {
            Location actualLocationById = World.LocationById(1);
            Assert.AreEqual("Your house. You really need to clean up the place.", actualLocationById.Description);
        }

        [TestMethod()]
        public void LocationByIdIdTooHighTest()
        {
            Location actualLocationById = World.LocationById(100);
            Assert.IsNull(actualLocationById);
        }

        [TestMethod()]
        public void LocationByIdItemRequiredToEnterTest()
        {
            Location actualLocationById = World.LocationById(1);
            Assert.IsNull(actualLocationById.ItemRequiredToEnter);
        }

        [TestMethod()]
        public void LocationByIdLocationToEastTest()
        {
            Location actualLocationById = World.LocationById(1);
            Assert.IsNull(actualLocationById.LocationToEast);
        }

        [TestMethod()]
        public void LocationByIdLocationToSouthTest()
        {
            Location actualLocationById = World.LocationById(1);
            Assert.IsNull(actualLocationById.LocationToSouth);
        }

        [TestMethod()]
        public void LocationByIdLocationToWestTest()
        {
            Location actualLocationById = World.LocationById(1);
            Assert.IsNull(actualLocationById.LocationToWest);
        }

        [TestMethod()]
        public void LocationByIdLocationToNorthTest()
        {
            Location actualLocationById = World.LocationById(1);
            Assert.AreEqual(World.LocationById(2).Id, actualLocationById.LocationToNorth.Id);
        }

        [TestMethod()]
        public void LocationByIdMonsterLivingHereTest()
        {
            Location actualLocationById = World.LocationById(1);
            Assert.IsNull(actualLocationById.MonsterLivingHere);
        }

        [TestMethod()]
        public void LocationByIdQuestAvailableHereTest()
        {
            Location actualLocationById = World.LocationById(1);
            Assert.IsNull(actualLocationById.QuestAvailableHere);
        }
        #endregion
    }
}