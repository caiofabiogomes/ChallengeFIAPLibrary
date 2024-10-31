using ChallengeFIAPLibrary.Domain.Entities;
using MongoDB.Driver;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence
{
    public class ReadDbContext
    {
        private readonly IMongoDatabase _database;

        public ReadDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
         
        public IMongoCollection<Author> Authors => _database.GetCollection<Author>("Authors");
        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customers");
        public IMongoCollection<Book> Books => _database.GetCollection<Book>("Books");
        public IMongoCollection<Loan> Loans => _database.GetCollection<Loan>("Loans");
         
        public IQueryable<T> Query<T>() where T : BaseEntity
        {
            return Set<T>().AsQueryable().Where(e => !e.IsDeleted);
        }
         
        public IMongoCollection<T> Set<T>() where T : BaseEntity
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }
    }
}
