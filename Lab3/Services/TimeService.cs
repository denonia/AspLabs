namespace Lab3.Services;

public class TimeService : ITimeService
{
    public string GetTimeString()
    {
        return DateTime.Now.Hour switch
        { 
            >= 12 and <= 18 => "зараз день",
            >= 18 and <= 24 => "зараз вечір",
            >= 0 and <= 6 => "зараз ніч",
            >= 6 and <= 12 => "зараз ранок"
        };
    }
}