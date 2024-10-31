using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Queries.GetAllLoans
{
    public class GetAllLoansQuery : IRequest<Result<List<LoanViewModel>>>
    {
    }
}
