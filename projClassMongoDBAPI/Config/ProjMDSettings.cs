namespace projClassMongoDBAPI.Config
{
    public class ProjMDSettings : IProjMDSettings
    {
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
