using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tkc_test1.UnitTests
{
    [TestClass]
    public class DbMapperTests
    {
        [TestMethod]
        public void GetUniverseSize_NoParam_ReturnsInt()
        {
            // Arrange
            var dm = new DbMapper();
            int expectedCount = 1218996;

            // Act
            var result = dm.GetUniverseSize();

            // Assert
            Assert.AreEqual(result, expectedCount);
            
        }
    }
}
