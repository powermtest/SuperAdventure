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
                          && expectedPlayer.Level.Equals(60), "Player could not been created.");
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
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            Assert.IsTrue(createPlayer.HasRequiredItemToEnterThisLocation(location),
                "Entering 'home' apparently requires and item?");
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
            Assert.IsTrue(createPlayer.HasRequiredItemToEnterThisLocation(location), 
                "Assigned item is not enough to enter the location!");
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
            Assert.IsFalse(createPlayer.HasRequiredItemToEnterThisLocation(location), 
                "'Adventurer pass' item should be required to enter the 'Guard post' location, and it is not");
        }

        [TestMethod()]
        public void HasThisQuestQuestIdMatchesTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            Quest zadanie = World.QuestById(1);
            PlayerQuest zadanieGracza = new PlayerQuest(zadanie);
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.Quests.Add(zadanieGracza);
            Assert.IsTrue(createPlayer.HasThisQuest(zadanie), "'QuestId' does not match the expected");
        }

        [TestMethod()]
        public void HasThisQuestQuestIdDoesNotMatchTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            Quest zadanie = World.QuestById(1);
            Quest zadanieFalse = World.QuestById(2);
            PlayerQuest zadanieGracza = new PlayerQuest(zadanieFalse);
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.Quests.Add(zadanieGracza);
            Assert.IsFalse(createPlayer.HasThisQuest(zadanie), 
                "'QuestId' should be different for two separate quests");
        }

        [TestMethod()]
        public void CompletedThisQuestTrueMarkQuestCompletedTrueTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            Quest zadanie = World.QuestById(1);
            PlayerQuest zadanieGracza = new PlayerQuest(zadanie);
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.Quests.Add(zadanieGracza);
            createPlayer.MarkQuestCompleted(zadanie);
            createPlayer.CompletedThisQuest(zadanie);
            Assert.IsTrue(zadanieGracza.IsCompleted, "Quest is not marked as completed");
        }

        [TestMethod()]
        public void CompletedThisQuestFalseTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            Quest zadanie = World.QuestById(1);
            Quest zadanieFalse = World.QuestById(2);
            PlayerQuest zadanieGracza = new PlayerQuest(zadanieFalse);
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.Quests.Add(zadanieGracza);
            createPlayer.CompletedThisQuest(zadanie);
            Assert.IsFalse(zadanieGracza.IsCompleted, 
                "'QuestId' should be different for two separate quests, and it is not");
        }

        [TestMethod()]
        public void HasAllQuestCompletionItemSufficientItemQuantityTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            int itemId = 4;

            Quest zadanie = World.QuestById(2);
            PlayerQuest zadanieGracza = new PlayerQuest(zadanie);
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.AddItemToInventory(World.ItemById(itemId));
            createPlayer.AddItemToInventory(World.ItemById(itemId));
            createPlayer.AddItemToInventory(World.ItemById(itemId));
            createPlayer.Quests.Add(zadanieGracza);
            Assert.IsTrue(createPlayer.HasAllQuestCompletionItems(zadanie),
                "There are not enough items in the list after deduction");
        }

        [TestMethod()]
        public void HasAllQuestCompletionItemsInsufficientItemQuantityTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            int itemId = 4;

            Quest zadanie = World.QuestById(2);
            PlayerQuest zadanieGracza = new PlayerQuest(zadanie);
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.AddItemToInventory(World.ItemById(itemId));
            createPlayer.AddItemToInventory(World.ItemById(itemId));
            createPlayer.Quests.Add(zadanieGracza);
            Assert.IsFalse(createPlayer.HasAllQuestCompletionItems(zadanie),
                "Deducting items from the 'Items' list is not working properly " +
                "- there are too little items and yet the task was successful");
        }

        [TestMethod()]
        public void HasAllQuestCompletionItemsItemNotInInventoryTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            int itemQuantity = 4;

            Quest zadanie = World.QuestById(2);
            PlayerQuest zadanieGracza = new PlayerQuest(zadanie);
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.Quests.Add(zadanieGracza);

            Assert.IsFalse(createPlayer.HasAllQuestCompletionItems(zadanie),
                "Checking of required items to complete a quest is malfunctioning." +
                " No items are present in the list, yet the quest is completed.");
        }

        [TestMethod()]
        public void RemoveQuestCompletionItemsTwoDifferentItemsInListTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            int itemId = 2;
            int oczekiwanaLiczbaElementow = 2;

            Quest zadanie = World.QuestById(1);
            PlayerQuest zadanieGracza = new PlayerQuest(zadanie);
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.Quests.Add(zadanieGracza);
            createPlayer.AddItemToInventory(World.ItemById(itemId));
            createPlayer.AddItemToInventory(World.ItemById(itemId+2));
            createPlayer.RemoveQuestCompletionItems(zadanie);
            int faktycznaLiczbaElementowInventoryCount = createPlayer.Inventory.Count;
            Assert.AreEqual(oczekiwanaLiczbaElementow,faktycznaLiczbaElementowInventoryCount,
                "Too many items were deducted form the 'Items' list.");
        }

        [TestMethod()]
        public void RemoveQuestCompletionItemsWrongItemIdInListTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            int itemId = 1;
            int oczekiwanaLiczbaElementow = 1;

            Quest zadanie = World.QuestById(1);
            PlayerQuest zadanieGracza = new PlayerQuest(zadanie);
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.Quests.Add(zadanieGracza);
            createPlayer.AddItemToInventory(World.ItemById(itemId));
            createPlayer.RemoveQuestCompletionItems(zadanie);
            int faktycznaLiczbaElementowInventoryCount = createPlayer.Inventory.Count;
            Assert.AreEqual(oczekiwanaLiczbaElementow, faktycznaLiczbaElementowInventoryCount, 
                "Too many items required to finish the quest were deducted form the 'Items' list");
        }

        [TestMethod()]
        public void AddItemToInventoryTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            int itemId = 1;
            int oczekiwanaLiczbaElementow = 3;
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.AddItemToInventory(World.ItemById(itemId));
            createPlayer.AddItemToInventory(World.ItemById(itemId+1));
            createPlayer.AddItemToInventory(World.ItemById(itemId+2));
            int faktycznaLiczbaElementow = createPlayer.Inventory.Count;
            Assert.AreEqual(oczekiwanaLiczbaElementow,faktycznaLiczbaElementow, 
                "The number of added items is different than the number of elements in the list.");
        }

        [TestMethod()]
        public void MarkQuestCompletedFalseQuestAndPlayerQuestDoNotMatchTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            int itemId = 1;

            Quest zadanie = World.QuestById(1);
            Quest zadanieFalse = World.QuestById(2);
            PlayerQuest zadanieGracza = new PlayerQuest(zadanieFalse);
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.Quests.Add(zadanieGracza);
            createPlayer.MarkQuestCompleted(zadanie);
            Assert.IsFalse(zadanieGracza.IsCompleted, 
                "'QuestId' must not be the same for different quests");
            
        }

        [TestMethod]
        public void LocationTest()
        {
            string expectedLocationName = "Alchemist's garden";
            int expectedId = 5;
            string expectedLocationToSouthName = "Alchemist's hut";
            string expectedMonsterLivingHereName = "Rat";
            int currentHitPoints = 100;
            int maximumHitPoints = 100;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;

            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            createPlayer.CurrentLocation = World.LocationById(5);
            var gdzie = createPlayer.CurrentLocation;

            Assert.AreEqual(expectedLocationName,gdzie.Name,
                "Name of the Location is different");
            Assert.AreEqual(expectedId, gdzie.Id,
                "ID of the Location is different");
            Assert.IsNull(gdzie.ItemRequiredToEnter,
                "There should be no required item to enter this location");
            Assert.IsNull(gdzie.LocationToEast,
                "Eastern location should not exist");
            Assert.IsNull(gdzie.LocationToNorth,
                "Northern location should not exist");
            Assert.AreEqual(expectedLocationToSouthName, gdzie.LocationToSouth.Name,
                "Southern location's name is different");
            Assert.IsNull(gdzie.LocationToWest,
                "Western location should not exist");
            Assert.AreEqual(expectedMonsterLivingHereName, gdzie.MonsterLivingHere.Name,
                "Name of the monster is different");
            Assert.IsNull(gdzie.QuestAvailableHere,
                "No quest should be available here");


        }
    }
}