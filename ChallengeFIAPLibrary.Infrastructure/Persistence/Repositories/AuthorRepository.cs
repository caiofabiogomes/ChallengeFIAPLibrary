using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Repositories
{
    public class AuthorRepository(WriteDbContext context, ReadDbContext readDbContext) : AbstractRepository<Author>(context, readDbContext), IAuthorRepository;
}
