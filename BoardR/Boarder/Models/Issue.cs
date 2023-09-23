using System;

namespace Boarder.Models
{
    public class Issue : BoardItem
    {
        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate)
        {
            this.Description = description ?? "No desciption";

            this.AddEventLog($"Created Issue: {this.ViewInfo()}. Description: {this.Description}");

            Status = Status.Open;
        }

        public string Description { get; }

        public override void RevertStatus()
        {
            if (Status == Status.Verified)
            {
                Status = Status.Open;

                this.AddEventLog("Issue status set to Open");
            }
            else
                this.AddEventLog("Issue status already Open");

        }

        public override void AdvanceStatus()
        {
            if (Status == Status.Open)
            {
                Status = Status.Verified;

                this.AddEventLog("Issue status set to Verified");
            }
            else
                this.AddEventLog("Issue status already Verified");
        }
    }
}
