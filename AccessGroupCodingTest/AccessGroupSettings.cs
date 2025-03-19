namespace AccessGroupCodingTest;

public class AccessGroupSettings
{
    public AccessGroupSettings(IConfiguration config)
    {
        config.GetSection("AccessGroup").Bind(this, c => c.BindNonPublicProperties = true);
    }

    public string BaseUrl { get; init; } = null!;
}