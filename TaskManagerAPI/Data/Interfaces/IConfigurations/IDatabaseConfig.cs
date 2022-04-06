namespace TaskManagerAPI.Data.Interfaces.IConfigurations
{
    public interface IDatabaseConfig
    {
        string DatabaseName { get; set; }

        string ConnectionString { get; set; }

    }
}
