using Microsoft.AspNetCore.Mvc;

namespace AccessGroupCodingTest.Test1;

[ApiController]
public class Test1Controller(ITestService service) : ControllerBase
{
    [HttpGet("/")]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var dividendOutputs = await service.GetDividendOutputsAsync(ct);
        return new DividendOutputResult(dividendOutputs);
    }
}

internal class DividendOutputResult(IEnumerable<DividendOutput> dividendOutputs) : IActionResult
{
    public async Task ExecuteResultAsync(ActionContext context)
    {
        var response = context.HttpContext.Response;
        var ct = context.HttpContext.RequestAborted;
        
        response.ContentType = "text/plain";

        foreach (var dividendOutput in dividendOutputs)
        {
            await response.WriteAsync(dividendOutput.Dividend.ToString(), ct);
            await response.WriteAsync(": ", ct);

            foreach (var divisorOutput in dividendOutput.DivisorOutputs)
            {
                await response.WriteAsync(divisorOutput, ct);
            }

            await response.WriteAsync("\n", ct);
        }
    }
}