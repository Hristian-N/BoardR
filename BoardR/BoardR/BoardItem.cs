using System.Text;

class BoardItem
{
    string title;
    DateTime dueDate;
    Status status;
    List<EventLog> logs = new List<EventLog>();

    public BoardItem(string title, DateTime dueDate)
    {

        Title = title;
        DueDate = dueDate;
        this.status = Status.Open;

        EventLog log = new EventLog($"Item created: \'{Title}\', [{Status} | {DueDate.ToString("dd-MM-yyyy")}]");
        logs.Add(log);
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

            EventLog log = new EventLog($"Title changed from \'{Title}\' to \'{value}\'");
            logs.Add(log);
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

            EventLog log = new EventLog($"DueDate changed from {DueDate.ToString("dd-MM-yyyy")} to {value.ToString("dd-MM-yyyy")}");
            logs.Add(log);
            this.dueDate = value;
        }
    }

    public Status Status
    {
        get { return this.status; }
    } 

    public void RevertStatus()
    {
        if (this.status != Status.Open)
        {
            Status tmp = Status;
            EventLog log = new EventLog($"Status changed from {Status} to {--tmp}");
            logs.Add(log);
            this.status--;
        }
            
        else
        {
            EventLog log = new EventLog("Can't revert, already at Open");
            logs.Add(log);
        } 
    }

    public void AdvanceStatus()
    {
        if (this.status != Status.Verified)
        {
            Status tmp = Status;
            EventLog log = new EventLog($"Status changed from {Status} to {++tmp}");
            logs.Add(log);
            this.status++;
        }

        else
        {
            EventLog log = new EventLog("Can't advance, already at Verified");
            logs.Add(log);
        }
    }

    public string ViewInfo()
    {
        return $"{title}, [{status}|{this.dueDate.ToString("dd-MM-yyyy")}]";
    }

    public string ViewHistory()
    {

        logs.RemoveAt(0);
        logs.RemoveAt(0);

        StringBuilder stringBuilder = new StringBuilder();
        foreach(EventLog log in logs)
            stringBuilder.Append(log.ViewInfo() + '\n');

        return stringBuilder.ToString();
    }
}
