namespace AsyncApi.Infrastructure.Database.Repositories;

public class DbConnectionConfiguration
{
    public const string DefaultKey = "Default";
    public string Provider { get; set; } = "";
    public string ConnectionString { get; set; } = "";
}