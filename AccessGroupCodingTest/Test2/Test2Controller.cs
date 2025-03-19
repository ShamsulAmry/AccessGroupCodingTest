using Microsoft.AspNetCore.Mvc;

namespace AccessGroupCodingTest.Test2;

[ApiController]
public class Test2Controller : ControllerBase
{
    [HttpPost("/test2")]
    public IActionResult Post()
    {
        throw new NotImplementedException();
    }
}