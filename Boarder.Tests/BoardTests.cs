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
