using ChallengeFIAPLibrary.Domain.Entities;
using MongoDB.Driver;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence
{
    public class ReadDbContext
    {
        private readonly IMongoDatabase _database;
         
        private readonly Dictionary<string, string> _collectionMappings = new Dictionary<string, string>
        {
            { nameof(Author), "authors" },
            { nameof(Customer), "customers" },
            { nameof(Book), "books" },
            { nameof(Loan), "loans" }
        };

        public ReadDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Author> Authors => _database.GetCollection<Author>("authors");
        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("customers");
        public IMongoCollection<Book> Books => _database.GetCollection<Book>("books");
        public IMongoCollection<Loan> Loans => _database.GetCollection<Loan>("loans");

        public IQueryable<T> Query<T>() where T : BaseEntity
        {
            return Set<T>().AsQueryable().Where(e => !e.IsDeleted);
        }

        public IMongoCollection<T> Set<T>() where T : BaseEntity
        {
            var collectionName = _collectionMappings[typeof(T).Name];
            return _database.GetCollection<T>(collectionName);
        }
    }
}
