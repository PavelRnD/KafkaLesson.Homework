namespace KafkaLesson.Homework;

public class EventStorage
{
    private static readonly Lazy<EventStorage> Lazy = new(() => new EventStorage());
    public static EventStorage Instance => Lazy.Value;
    private EventStorage() { }

    private readonly object _lockObject = new ();
    
    private readonly List<TestEvent> _processedEvents = [];
    
    private int count = 0;
    public int Count {get {return count;}}

    public void AddProcessedEvent(TestEvent ev)
    {
        _processedEvents.Add(ev);
    }

    public List<TestEvent> GetProcessedEvent()
    {
        return _processedEvents.ToList();
    }

    internal void Increment()
    {
        lock(_lockObject)
        {
            count++;
        }
    }
}