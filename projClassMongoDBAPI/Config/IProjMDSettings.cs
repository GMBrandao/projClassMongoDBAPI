namespace projClassMongoDBAPI.Config
{
    public interface IProjMDSettings
    {
        string CustomerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
