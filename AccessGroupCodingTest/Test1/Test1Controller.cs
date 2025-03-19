using Microsoft.AspNetCore.Mvc;

namespace AccessGroupCodingTest.Test1;

[ApiController]
public class Test1Controller : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Get()
    {
        throw new NotImplementedException();
    }
}