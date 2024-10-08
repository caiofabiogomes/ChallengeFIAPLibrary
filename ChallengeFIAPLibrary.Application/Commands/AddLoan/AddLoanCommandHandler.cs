using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;
using ChallengeFIAPLibrary.Domain.ValueObjects;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Commands.AddLoan
{
    public class AddLoanCommandHandler : IRequestHandler<AddLoanCommand, Result<Unit>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        public AddLoanCommandHandler(ILoanRepository loanRepository, ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _loanRepository = loanRepository;
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Result<Unit>> Handle(AddLoanCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            
            if (customer == null) 
                return Result<Unit>.Failure("Customer not found"); 

            var book = await _bookRepository.GetByIdAsync(request.BookId);

            if (book == null) 
                return Result<Unit>.Failure("Book not found");

            var valueToPayPerDay = new ValueToPayCurrency()
            {
                Currency = request.Currency,
                Value = request.ValuePerDay
            };

            var valueToPayPerDayLate = new ValueToPayCurrency()
            {
                Currency = request.Currency,
                Value = request.ValuePerDayLate
            };

            var loan = new Loan(customer.Id, book.Id, request.StartDateLoan, request.EndDateLoan, valueToPayPerDay, valueToPayPerDayLate);

            await _loanRepository.AddAsync(loan);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
