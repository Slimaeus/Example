using Example.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CountersController : ControllerBase
{
    private readonly ITransientCounterService _transientCounterService1;
    private readonly ITransientCounterService _transientCounterService2;
    private readonly IScopedCounterService _scopedCounterService2;
    private readonly IScopedCounterService _scopedCounterService1;
    private readonly ISingletonCounterService _singletonCounterService1;
    private readonly ISingletonCounterService _singletonCounterService2;

    public CountersController(
        ITransientCounterService transientCounterService1,
        ITransientCounterService transientCounterService2,
        IScopedCounterService scopedCounterService1,
        IScopedCounterService scopedCounterService2,
        ISingletonCounterService singletonCounterService1,
        ISingletonCounterService singletonCounterService2)
    {
        _transientCounterService1 = transientCounterService1;
        _transientCounterService2 = transientCounterService2;
        _scopedCounterService1 = scopedCounterService1;
        _scopedCounterService2 = scopedCounterService2;
        _singletonCounterService1 = singletonCounterService1;
        _singletonCounterService2 = singletonCounterService2;
    }

    [HttpGet("transient")]
    public dynamic Transient()
    {
        return new int[] { _transientCounterService1.RandomNumber, _transientCounterService2.RandomNumber };
    }
    [HttpGet("scoped")]
    public dynamic Scoped()
    {
        return new int[] { _scopedCounterService1.RandomNumber, _scopedCounterService2.RandomNumber };
    }
    [HttpGet("singleton")]
    public dynamic Singleton()
    {
        return new int[] { _singletonCounterService1.RandomNumber, _singletonCounterService2.RandomNumber };
    }
}
