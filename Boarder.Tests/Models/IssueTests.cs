using Boarder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder.Tests.Models
{
    [TestClass]
    public class IssueTests
    {
        string validTitle;
        string validDescription;
        DateTime validDueDate;
        Boarder.Models.Issue sut;

        [TestInitialize]
        public void Initialize()
        {
            validTitle = "This is a test title";
            validDescription = "The best description ever";
            validDueDate = DateTime.Now.AddDays(1);
            sut = new Boarder.Models.Issue(validTitle, validDescription, validDueDate);
        }

        [TestMethod]
        public void AdvanceStatus_Should_SetStatusToVerified_WhenCurrentStatusIsNotVerified()
        {
            // Arrange
            Status expectedStatus = Status.Verified;

            // Act
            sut.AdvanceStatus();

            // Assert
            Assert.AreEqual(expectedStatus, sut.Status);
        }

        [TestMethod]
        public void AdvanceStatus_Should_DoNothing_WhenCurrentStatusIsAlreadyVerified()
        {
            // Arrange
            Status expectedStatus = Status.Verified;
            sut.AdvanceStatus();

            // Act
            sut.AdvanceStatus();

            // Assert
            Assert.AreEqual(expectedStatus, sut.Status);
        }

        [TestMethod]
        public void RevertStatus_Should_SetCurrentStatusToOpen_WhenCurrentStatusIsNotTodo()
        {
            // Arrange
            Status expectedStatus = Status.Open;
            sut.AdvanceStatus();

            // Act
            sut.RevertStatus();

            // Assert
            Assert.AreEqual(expectedStatus, sut.Status);
        }

        [TestMethod]
        public void RevertStatus_Should_DoNothing_WhenCurrentStatusIsAlreadyOpen()
        {
            // Arrange
            Status expectedStatus = Status.Open;

            // Act
            sut.RevertStatus();

            // Assert
            Assert.AreEqual(expectedStatus, sut.Status);
        }
    }
}
