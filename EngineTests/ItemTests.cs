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
    public class ItemTests
    {
        [TestMethod(), TestCategory("HealingPotion"), TestCategory("Integration")]
        public void PlayerIsHealedWhenHealthPotionUsedTest()
        {
            int currentHitPoints = 100;
            int maximumHitPoints = 1000;
            int gold = 99;
            int experiencePoints = 500;
            int level = 60;
            int itemId = 1;
            int hpId = 7;
            string hpName = "HP";
            string hpNamePlural = "HPs";
            int hpPower = 123;
            int expectedHpAfterHealing = 223;
            Player createPlayer = new Player(currentHitPoints,
                maximumHitPoints,
                gold,
                experiencePoints,
                level);
            HealingPotion healingPotion = new HealingPotion(hpId, hpName, hpNamePlural, hpPower);
            createPlayer.AddItemToInventory(healingPotion);
            createPlayer.CurrentHitPoints = 100;
            int actualHpAfterHealing = createPlayer.CurrentHitPoints + healingPotion.AmountToHeal;
            Assert.AreEqual(expectedHpAfterHealing, actualHpAfterHealing);

        }
    }
}