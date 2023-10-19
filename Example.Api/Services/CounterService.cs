namespace Example.Api.Services;

public class CounterService : IScopedCounterService, ISingletonCounterService, ITransientCounterService
{
    public int RandomNumber { get; set; }
    public CounterService()
    {
        RandomNumber = new Random().Next();
    }
}
