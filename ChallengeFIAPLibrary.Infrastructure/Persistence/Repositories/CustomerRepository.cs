using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository(WriteDbContext context, ReadDbContext readDbContext) : AbstractRepository<Customer>(context, readDbContext), ICustomerRepository;
}
