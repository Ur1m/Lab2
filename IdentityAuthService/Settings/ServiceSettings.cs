namespace IdentityAuthService
{
    public class ServiceSettings
    {
        public string ServiceName { get; init; }

        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string CollectionName { get; set; } = string.Empty;


    }
}