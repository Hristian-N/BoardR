using Boarder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void TotalItems_Should_ReturnTheCountOfItems()
        {
            // Arrange
            Boarder.Models.Task task = new Boarder.Models.Task("Write unit tests", "Peter", DateTime.Now.AddDays(1));
            Board.AddItem(task);
            int expectedCount = 3;

            // Act & Assert
            Assert.AreEqual(expectedCount, Board.TotalItems);           
        }

        [TestMethod]
        public void AddItem_Should_Item_When_ValidationHasPassedSuccessfully()
        {
            // Arrange
            BoardItem task = new Boarder.Models.Task("Write unit tests", "Peter", DateTime.Now.AddDays(1));
            int expectedCount = 1;

            // Act
            Board.AddItem(task);

            // Assert
            Assert.AreEqual(Board.TotalItems, expectedCount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddItem_Should_Throw_WhenItemAlreadyExist()
        {
            // Arrange
            BoardItem task = new Boarder.Models.Task("Write unit tests", "Peter", DateTime.Now.AddDays(1));
            Board.AddItem(task);

            // Act & Assert
            Board.AddItem(task);
        }
    }
}
