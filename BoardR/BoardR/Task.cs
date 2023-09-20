
using System.Diagnostics.Metrics;
using System.Threading.Channels;

public class Task : BoardItem
{

    private string assignee;
    bool isLocked = true;

    public Task(string title, string assignee, DateTime dueDate) : base(title, dueDate, true)
    {
        Assignee = assignee;
        this.status = Status.Todo;

        AddLog(new EventLog($"Created Task: {this.ViewInfo()}"));
    }

    public string Assignee
    {
        get
        {
            return this.assignee;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Assignee cannot be null or empty");

            if (value.Length < 5 || value.Length > 30)
                throw new ArgumentException("Assignee cannot be null or empty");

            if (!isLocked)
            {
                AddLog(new EventLog($"Assignee changed from {Assignee} to {value}"));
            }

            isLocked = false;
            this.assignee = value;
        }
    }
}


