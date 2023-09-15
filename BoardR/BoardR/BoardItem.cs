class BoardItem
{
    string title;
    DateTime dueDate;
    public Status status;

    public BoardItem(string title, DateTime dueDate)
    {
        if(title.IsNullOrEmpty(title))
            throw new ArgumentNullException("Title cannot be null or empty");
        if (title.Length > 30 || title.Length < 5)
            throw new ArgumentException("Title must be between 5 and 30 characters long");
        if (dueDate < DateTime.Now)
            throw new ArgumentException("Due date cannot cannot be in the past");
        
        this.dueDate = dueDate;
        this.title = title;
        this.status = Status.Open;
    }

    public void RevertStatus()
    {
        if (this.status != Status.Open)
            return this.status--;
    }

    public void AdvanceStatus()
    {
        if (this.status != Status.Verified)
            return this.status++;
    }

    public string ViewInfo()
    {
        return $"{title}, [{status}|{this.dueDate.ToString("dd-MM-yyyy")}]";
    }
}
