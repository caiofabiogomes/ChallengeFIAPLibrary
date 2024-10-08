using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Domain.Enums;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Commands.AddLoan
{
    public class AddLoanCommand : IRequest<Result<Unit>>
    {
        public Guid CustomerId { get; set; }

        public Guid BookId { get; set; }

        public DateTime StartDateLoan { get; set; }

        public DateTime EndDateLoan { get; set; }

        public decimal ValuePerDay { get; set; }

        public decimal ValuePerDayLate { get; set; }

        public ECurrency Currency { get; set; }

    }
}
