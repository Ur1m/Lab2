namespace Play.Products.Service
{
    public class MongoDbSettings
    {
        public string Host { get; init; }
        public int Port { get; init; }

        public string ConnectionString => $"mongodb+srv://{Host}:{Port}";
    }
}