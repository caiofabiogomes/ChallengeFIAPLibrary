using AutoMapper;
using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using ChallengeFIAPLibrary.Domain.Repositories;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Queries.GetAllLoans
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, Result<List<LoanViewModel>>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public GetAllLoansQueryHandler(ILoanRepository loanRepository, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<LoanViewModel>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loans = await _loanRepository.GetAllAsync();

            var loansResult = _mapper.Map<List<LoanViewModel>>(loans);

            return Result<List<LoanViewModel>>.Success(loansResult);
        }
    }
}
