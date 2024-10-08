using ChallengeFIAPLibrary.Domain.Enums;
using ChallengeFIAPLibrary.Domain.Exceptions;
using ChallengeFIAPLibrary.Domain.ValueObjects;

namespace ChallengeFIAPLibrary.Domain.Entities
{
    public class Loan : BaseEntity
    {
        public Loan()
        {
            
        }

        public Loan(Guid customerId, Guid bookId, DateTime startDateLoan, 
            DateTime endDateLoan, ValueToPayCurrency valuePerDay, ValueToPayCurrency valuePerDayLate)
        {
            CustomerId = customerId;
            BookId = bookId;
            StartDateLoan = startDateLoan;
            EndDateLoan = endDateLoan;
            ValuePerDay = valuePerDay;
            ValuePerDayLate = valuePerDayLate;
            Status = ELoanStatus.InProgress;
        }
        public Guid CustomerId { get; private set; }

        public Customer Customer { get; private set; }

        public Guid BookId { get; private set; }

        public Book Book { get; private set; }

        public DateTime StartDateLoan { get; private set; }

        public DateTime EndDateLoan { get; private set; }

        public DateTime? DeliveryDateLoan { get; private set; }

        public ELoanStatus Status { get; private set; }

        public ValueToPayCurrency ValuePerDay { get; private set; }

        public ValueToPayCurrency ValuePerDayLate { get; private set; }

        public ValueToPayCurrency? TotalValuePaid { get; private set; }

        public void FinishLoan(DateTime finishDate, ValueToPayCurrency totalValuePaid)
        {
            if (Status == ELoanStatus.PaymentPending)
            {
                Status = ELoanStatus.Payed;
                DeliveryDateLoan = finishDate;
                TotalValuePaid = totalValuePaid;
                ValidateFinishLoanDate();
            }
        }

        public void CancelLoan()
        {
            Status = ELoanStatus.Canceled;
        }

        public void PaymentPending()
        {
            Status = ELoanStatus.PaymentPending;
        }

        private void ValidateFinishLoanDate()
        {
            if (DeliveryDateLoan < StartDateLoan)
                throw new EndDateLoanInvalidException("The loan finish date cannot be less than the start date.");
        }

        private void ValidateEndLoanDate()
        {
            if (EndDateLoan < StartDateLoan)
                throw new EndDateLoanInvalidException("The loan end date cannot be less than the start date.");
        }
    }
}
