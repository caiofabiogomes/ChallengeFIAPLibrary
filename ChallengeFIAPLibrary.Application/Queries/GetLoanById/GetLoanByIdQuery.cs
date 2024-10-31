using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Queries.GetLoanById
{
    public class GetLoanByIdQuery : IRequest<Result<LoanViewModel>>
    {
        public Guid Id { get; set; }
    }
}
