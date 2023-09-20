using System.Text;

public class BoardItem
{
    string title;
    DateTime dueDate;
    protected Status status;
    protected List<EventLog> logs = new List<EventLog>();
    bool isOnce = true;

    public BoardItem(string title, DateTime dueDate, bool skipLog)
    {

        Title = title;
        DueDate = dueDate;
        this.status = Status.Open;

        if (!skipLog)
            AddLog(new EventLog($"Item created: {this.ViewInfo()}"));
    }

    public string Title
    {
        get
        {
            return this.title;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Title cannot be null or empty");
            if (value.Length > 30 || value.Length < 5)
                throw new ArgumentException("Title must be between 5 and 30 characters long");

            AddLog(new EventLog($"Title changed from \'{Title}\' to \'{value}\'"));
            this.title = value;
        }
    }

    public DateTime DueDate
    {
        get
        {
            return this.dueDate;
        }
        set
        {
            if (value < DateTime.Now)
                throw new ArgumentException("Due date cannot cannot be in the past");

            AddLog(new EventLog($"DueDate changed from {DueDate.ToString("dd-MM-yyyy")} to {value.ToString("dd-MM-yyyy")}"));
            this.dueDate = value;
        }
    }

    public Status Status
    {
        get
        {
            return this.status;
        }
    }

    public void AddLog(EventLog log)
    {
        logs.Add(log);
    }

    public void RevertStatus()
    {
        if (this.status != Status.Open)
        {
            Status tmp = Status;
            AddLog(new EventLog($"Status changed from {Status} to {--tmp}"));
            this.status--;
        }
        else
            AddLog(new EventLog("Can't revert, already at Open"));
    }

    public void AdvanceStatus()
    {
        if (this.status != Status.Verified)
        {
            Status tmp = Status;
            AddLog(new EventLog($"Status changed from {Status} to {++tmp}"));
            this.status++;
        }

        else
            AddLog(new EventLog("Can't advance, already at Verified"));
    }

    public string ViewInfo()
    {
        return $"{title}, [{status}|{this.dueDate.ToString("dd-MM-yyyy")}]";
    }

    public string ViewHistory()
    {
        if (isOnce)
        {
            logs.RemoveAt(0);
            logs.RemoveAt(0);
            isOnce = false;
        }

        StringBuilder stringBuilder = new StringBuilder();
        foreach (EventLog log in logs)
            stringBuilder.Append(log.ViewInfo() + '\n');

        return stringBuilder.ToString();
    }
}
