using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository(WriteDbContext context) : AbstractRepository<Customer>(context), ICustomerRepository;
}
