using Microsoft.AspNetCore.Mvc;

namespace AccessGroupCodingTest.Test2;

[ApiController]
public class Test2Controller(ITest2Service service) : ControllerBase
{
    [HttpPost("/test2")]
    public Task Post(CancellationToken ct) => service.ExecuteAsync(ct);
}