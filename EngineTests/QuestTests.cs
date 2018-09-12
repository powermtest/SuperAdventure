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
    public class QuestTests
    {
        [TestMethod()]
        public void QuestTest()
        {
            int expectedId = 2;
            string expectedName = "Clear the farmer's field";
            string expectedDescription = "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.";
            int expectedRewardExpPoints = 20;
            int expectedRewardGold = 20;
            int expectedRewardItemId = 10;

            Quest zadanie = World.QuestById(2);

            Assert.AreEqual(expectedId, zadanie.Id,
                "ID of the quest is different");
            Assert.AreEqual(expectedName, zadanie.Name,
                "Name of the quest is different");
            Assert.AreEqual(expectedRewardExpPoints, zadanie.RewardExperiencePoints,
                "Different amount of experience points for the quest");
            Assert.AreEqual(expectedRewardGold, zadanie.RewardGold,
                "Different amount of gold for the quest");
            Assert.AreEqual(expectedRewardItemId, zadanie.RewardItem.Id,
                "Reward item ID is different");
        }
    }
}