using FullstackMVC;
using FullstackMVC.Engine;
using NUnit.Framework;

namespace FullstackMVCTests
{
    public class LevelPropertiesTests
    {
     
        [TestCase(2, 1)]
        [TestCase(100, 2)]      
        [TestCase(500, 3)]      
        [Test]
        public void LevelProperties_CalculateLevel_LevelIsEqualToCurrentExperience(int inputValue, int expectedResult)
        {
            var result = LevelProperties.CalculateLevel(inputValue);
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedResult, result);
        }



        [TestCase(2, 50)]
        [TestCase(100, 300)]
        [TestCase(500, 1500)]
        [Test]
        public void LevelProperties_CalculateExpNeededToLevelUp(int inputValue, int expectedResult)
        {
            var result = LevelProperties.CalculateExpNeededToLevelUp(inputValue);
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedResult, result);
        }

    }
}