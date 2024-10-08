using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Repositories
{
    public class BookRepository(WriteDbContext context) : AbstractRepository<Book>(context), IBookRepository;
}
