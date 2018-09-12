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
    public class WeaponTests
    {
        [TestMethod()]
        public void WeaponTest()
        {

            int weaponId = 6;
            string weaponName = "Club";
            string weaponNamePlural = "Clubs";
            int weaponMinDmg = 3;
            int weaponMaxDmg = 10;
            Weapon bronislawa = new Weapon(6, "Club", "Clubs", 3, 10);

            Assert.AreEqual(weaponId, bronislawa.Id);
            Assert.AreEqual(weaponName, bronislawa.Name);
            Assert.AreEqual(weaponNamePlural, bronislawa.NamePlural);
            Assert.AreEqual(weaponMinDmg, bronislawa.MinimumDamage);
            Assert.AreEqual(weaponMaxDmg, bronislawa.MaximumDamage);
        }
    }
}