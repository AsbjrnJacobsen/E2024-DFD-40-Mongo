using System.Linq.Expressions;
using MongoDB.Driver;

namespace BloggingPlatformAssignment;

public class MongoDBContext
{
    private readonly string _connectionString;
    private readonly IMongoClient _client;

    private readonly string _databaseName;
    private readonly string _collectionName;


    public MongoDBContext(string connectionString, string databaseName, string collectionName)
    {
        _databaseName = databaseName;
        _collectionName = collectionName;
        _connectionString = connectionString;
        _client = new MongoClient(_connectionString);
    }

    private IMongoCollection<T> Collection<T>()
    {
        return _client.GetDatabase(_databaseName).GetCollection<T>(_collectionName);
    }

    public async void InsertOne<T>(T document)
    {
        await Collection<T>().InsertOneAsync(document);
    }

    public async void InsertMany<T>(IEnumerable<T> documents)
    {
        await Collection<T>().InsertManyAsync(documents);
    }

    public async void DeleteOne<T>(Expression<Func<T, bool>> predicate)
    {
        await Collection<T>().DeleteOneAsync(predicate);
    }

    public async void DeleteMany<T>(Expression<Func<T, bool>> predicate)
    {
        await Collection<T>().DeleteManyAsync(predicate);
    }

    public async Task<IAsyncCursor<T>> Find<T>(Expression<Func<T, bool>> predicate)
    {
        return await Collection<T>().FindAsync(predicate);
    }

    public async void ReplaceOne<T>(Expression<Func<T, bool>> predicate, T document)
    {
        await Collection<T>().ReplaceOneAsync(predicate, document);
    }
    
    public async void UpdateOne<T>(FilterDefinition<T> filter, UpdateDefinition<T> updateExpression)
    {
        await Collection<T>().UpdateOneAsync(filter, updateExpression);
    }
}