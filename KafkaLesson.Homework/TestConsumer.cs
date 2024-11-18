using Dodo.Kafka.Consumer;

namespace KafkaLesson.Homework;

public class TestConsumer : IConsumer<TestEvent>
{
    public async Task Consume(TestEvent ev, CancellationToken ct)
    {
        await Task.CompletedTask;
        var eventStorage = EventStorage.Instance;

        var latestEvent = eventStorage.GetProcessedEvent().FirstOrDefault(x => x.Id == ev.Id && x.Version >= ev.Version );
        if(latestEvent == null)
            eventStorage.AddProcessedEvent(ev);
    }
}