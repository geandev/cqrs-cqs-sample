using MongoDB.Driver;

namespace Infra.Mongo
{
    public class MongoRepository<TEntity>
    {
        private readonly IMongoDatabase _database;

        public MongoRepository(string connectionString, string databaseName)
        {
            _database = new MongoClient(connectionString).GetDatabase(databaseName);
        }

        public IMongoCollection<TEntity> GetCollection()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}
