
public sealed class EventLog
{
    readonly string description;
    readonly DateTime time;

    public EventLog(string description)
    {
        if (string.IsNullOrEmpty(description))
            throw new ArgumentNullException("Value cannot be null");

        this.description = description;
        this.time = DateTime.Now;
    }

    public string Description
    {
        get
        {
            return this.description;
        }
    }

    public DateTime Time
    {
        get
        {
            return this.time;
        }
    }

    public string ViewInfo()
    {
        return $"[{Time}]{Description}";
    }
}