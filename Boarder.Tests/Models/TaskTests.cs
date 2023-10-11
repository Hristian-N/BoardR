using Boarder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Boarder.Tests.Models
{
    [TestClass]
    public class TaskTests
    {
        string validTitle;
        string validAssignee;
        DateTime validDueDate;
        Boarder.Models.Task sut;

        [TestInitialize]
        public void Initialize()
        {
            validTitle = "This is a test title";
            validAssignee = "TestUser";
            validDueDate = DateTime.Now.AddDays(1);
            sut = new Boarder.Models.Task(validTitle, validAssignee, validDueDate);
        }

        [TestMethod]
        public void Task_Should_DeriveFromBoardItem()
        {
            var type = typeof(Boarder.Models.Task);
            var isAssignable = typeof(BoardItem).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Task class does not derive from BoardItem base class!");
        }

        [TestMethod]
        public void Constructor_Should_CreatValidTask_WhenParametersAreValid()
        {
            // Act
            var sut = new Boarder.Models.Task(validTitle, validAssignee, validDueDate);

            // Assert
            Assert.AreEqual(validTitle, sut.Title);
            Assert.AreEqual(validAssignee, sut.Assignee);
            Assert.AreEqual(validDueDate, sut.DueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_Throw_When_TitleIsNullOrEmpty()
        {
            // Arrange
            string wrongTitle = "";

            // Act & Assert
            var sut = new Boarder.Models.Task(wrongTitle, validAssignee, validDueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_Throw_When_TitleIsTooShort()
        {
            // Arrange
            string wrongTitle = new string('a', 4);

            // Act & Assert
            var sut = new Boarder.Models.Task(wrongTitle, validAssignee, validDueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_Throw_When_TitleIsTooLong()
        {
            // Arrange
            string wrongTitle = new string('a', 31);

            // Act & Assert
            var sut = new Boarder.Models.Task(wrongTitle, validAssignee, validDueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please provide a non-null or empty value for Assignee")]
        public void Constructor_Should_Throw_When_AssigneeIsNullOrWhiteSpace()
        {
            // Arrange
            string wrongAssignee = "";

            // Act & Assert
            var sut = new Boarder.Models.Task(validTitle, wrongAssignee, validDueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Assignee must be more than 4 symbols")]
        public void Constructor_Should_Throw_When_AssigneeIsTooShort()
        {
            // Arrange
            string wrongAssignee = new string('a', 4);

            // Act & Assert
            var sut = new Boarder.Models.Task(validTitle, wrongAssignee, validDueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Assignee must be less than 31 symbols")]
        public void Constructor_Should_Throw_When_AssigneeIsTooLong()
        {
            // Arrange
            string wrongAssignee = new string('a', 31);

            // Act & Assert
            var sut = new Boarder.Models.Task(validTitle, wrongAssignee, validDueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "DueDate must be in the future and not in the past or today")]
        public void Constructor_Should_Throw_When_DueDateIsNowOrInThePast()
        {
            // Arrange
            DateTime wrongDueDate = DateTime.Now;

            // Act & Assert
            var sut = new Boarder.Models.Task(validTitle, validAssignee, wrongDueDate);
        }

        [TestMethod]
        public void Title_ShouldSetTitleToValue_WhenValidationHasPassedSuccessfuly()
        {

            // Arrange Act & Assert
            sut.Title = validTitle;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please provide a non-null or empty value for Title")]
        public void Title_Should_Throw_WhenTitleIsNullOrEmpty()
        {
            // Arrange
            string wrongTitle = "";

            // Act & Assert
            sut.Title = wrongTitle;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Title must be more than 4 symbols")]
        public void Title_Should_Throw_WhenTitleIsIsTooShort()
        {
            // Arrange
            string wrongTitle = new string('a', 4);

            // Act & Assert
            sut.Title = wrongTitle;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Title must be less than 31 symbols")]
        public void Title_Should_Throw_WhenTitleIsTooLong()
        {
            // Arrange
            string wrongTitle = new string('a', 31);

            // Act & Assert
            sut.Title = wrongTitle;
        }

        [TestMethod]
        public void Assignee_Should_SetTitleToValue_WhenValidationHasPassed()
        {
            // Arrange & Act & Assert
            sut.Assignee = validAssignee;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please provide a non-null or empty value for Assignee")]
        public void Assignee_Should_Throw_WhenAssigneeIsNullOrWhiteSpace()
        {
            // Arrange
            string wrongAssignee = "";

            // Act & Assert
            sut.Assignee = wrongAssignee;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Assignee must be more than 4 symbols")]
        public void Assignee_Should_Throw_AssigneeIsTooShort()
        {
            // Arrange
            string wrongAssignee = new string('a', 4);

            // Act & Assert
            sut.Assignee = wrongAssignee;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Assignee must be less than 31 symbols")]
        public void Assignee_ShouldThrow_AssigneeIsTooLong()
        {
            // Arrange
            string wrongAssignee = new string('a', 31);

            // Act & Assert
            sut.Assignee = wrongAssignee;
        }

        [TestMethod]
        public void DueDate_Should_SetDueDateToValue_WhenValidationHasPassedSuccessfuly()
        {

            // Arrange & Act & Assert
            sut.DueDate = validDueDate;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "DueDate must be in the future and not in the past or today")]
        public void DueDate_Should_Throw_When_DueDateIsNowOrInThePast()
        {
            // Arrange
            DateTime wrongdueDate = DateTime.Now;

            // Act & Assert
            sut.DueDate = wrongdueDate;
        }

        [TestMethod]
        public void AdvanceStatus_Should_AdvanceTheStatus_UntilStatusIsVerified()
        {
            // Arrange
            Status expectedStatus = Status.Verified;
            int enumSize = Enum.GetValues(typeof(Status)).Length + 1;

            // Act
            for (int i = 0; i < enumSize; i++)
            {
                sut.AdvanceStatus();
            }

            // Assert
            Assert.AreEqual(sut.Status, expectedStatus);
        }

        [TestMethod]
        public void RevertStatus_Should_ReverseTheStatus_UntilStatusIsTodo()
        {
            // Arrange
            Status expectedStatus = Status.Todo;
            Status[] statusArray = (Status[])Enum.GetValues(typeof(Status));
            for (int i = 0; i < statusArray.Length+1; i++)
            {
                sut.AdvanceStatus();
            }


            // Act
            for (int i = 0; i < statusArray.Length + 1; i++)
            {
                sut.RevertStatus();
            }

            // Assert
            Assert.AreEqual(sut.Status, expectedStatus);
        }
    }
}
