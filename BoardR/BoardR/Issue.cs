
public class Issue : BoardItem
{

    readonly string description;

    public Issue(string title, string description, DateTime dueDate) : base(title, dueDate, Status.Open)
    {
        Description = description;

        AddLog(new EventLog($"Created Issue: {this.ViewInfo()}. Description: {description}"));
    }

    public string Description
    {
        get
        {
            return this.description;
        }
        init
        {
            if (string.IsNullOrEmpty(value))
                this.description = "No description";
            else
                this.description = value;
        }
    }
}


