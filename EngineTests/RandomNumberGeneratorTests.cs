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
    public class RandomNumberGeneratorTests
    {
        [TestMethod()]
        public void NumberBetweenMinAndMaxTest()
        {
            int minimumValue = 5;
            int maximumValue = 7;
            int expected = Engine.RandomNumberGenerator.NumberBetween(minimumValue,maximumValue);

            Assert.IsTrue(minimumValue <= expected && expected <= maximumValue);
        }
    }
}