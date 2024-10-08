using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Repositories
{
    public class LoanRepository(WriteDbContext context) : AbstractRepository<Loan>(context), ILoanRepository;
}
