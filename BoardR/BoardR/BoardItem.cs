class BoardItem
{
    string title;
    DateTime dueDate;
    public Status status;

    public BoardItem(string title, DateTime dueDate)
    {
        this.title = title;
        this.dueDate = dueDate;
        this.status = Status.Open;
    }

    public Status RevertStatus()
    {
        if (status != Status.Open)
            return this.status--;

        return Status.Open;
    }

    public Status AdvanceStatus()
    {
        if (status != Status.Verified)
            return this.status++;

        return Status.Verified;
    }

    public string ViewInfo()
    {
        return $"{title}, [{status}|{this.dueDate.ToString("dd-MM-yyyy")}]";
    }
}