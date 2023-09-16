class BoardItem
{
    string title;
    DateTime dueDate;
    Status status;

    public BoardItem(string title, DateTime dueDate)
    {
        Title = title;
        Duedate = dueDate;
        this.status = Status.Open;
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

            this.title = value;
        }
    }

    public DateTime Duedate
    {
        get
        {
            return this.dueDate;
        }
        set
        {
            if (value < DateTime.Now)
                throw new ArgumentException("Due date cannot cannot be in the past");

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

    public void RevertStatus()
    {
        if (this.status != Status.Open)
            this.status--;
    }

    public void AdvanceStatus()
    {
        if (this.status != Status.Verified)
            this.status++;
    }

    public string ViewInfo()
    {
        return $"{title}, [{status}|{this.dueDate.ToString("dd-MM-yyyy")}]";
    }
}
