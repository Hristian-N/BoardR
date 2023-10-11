using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder.Tests.Models
{
    [TestClass]
    public class EventLogtests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Should_Throw_WhenDescriptionIsEmpty()
        {
            // Arrange
            string wrongDesacription = null;

            // Act & Assert
            Boarder.Models.EventLog eventLog = new Boarder.Models.EventLog(wrongDesacription);
        }
        [TestMethod]
        public void ViewInfo_Should_ReturnCorrectString()
        {
            // Arrange
            string description = "Test log entry";
            Boarder.Models.EventLog eventLog = new Boarder.Models.EventLog(description);
            string time = eventLog.Time.ToString("yyyyMMdd|HH:mm:ss.ffff");

            // Act
            string formattedInfo = eventLog.ViewInfo();

            // Assert
            string expectedInfo = $"[{time}]Test log entry";
            Assert.AreEqual(expectedInfo, formattedInfo);
        }
    }
}
