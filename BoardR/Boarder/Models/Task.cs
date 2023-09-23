using System;

namespace Boarder.Models
{
    public class Task : BoardItem
    {
        private string assignee;

        public Task(string title, string assignee, DateTime dueDate)
            : base(title, dueDate)
        {
            this.EnsureValidAssignee(assignee);
            this.assignee = assignee;
            this.AddEventLog($"Created Task: {this.ViewInfo()}");

            Status = Status.Todo;
        }

        public string Assignee
        {
            get
            {
                return this.assignee;
            }
            set
            {
                this.EnsureValidAssignee(value);
                this.AddEventLog($"Assignee changed from {this.assignee} to {value}");
                this.assignee = value;
            }
        }

        public override void RevertStatus()
        {
            if (Status != Status.Todo)
            {
                var prevStatus = Status;
                Status--;

                this.AddEventLog($"Task changed from {prevStatus} to {Status}");
            }
            else
            {
                this.AddEventLog($"Task status already at {Status}");
            }
        }

        public override void AdvanceStatus()
        {
            if (Status != Status.Verified)
            {
                var prevStatus = Status;
                Status++;

                this.AddEventLog($"Task changed from {prevStatus} to {Status}");
            }
            else
            {
                this.AddEventLog($"Task status already at {Status}");
            }
        }

        private void EnsureValidAssignee(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Please provide a non-null or empty value");
            }

            if (value.Length < 5 || value.Length > 30)
            {
                throw new ArgumentException("Please provide a value in range [5..30]");
            }
        }
    }
}
