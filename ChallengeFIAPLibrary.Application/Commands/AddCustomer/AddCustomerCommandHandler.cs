using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;
using ChallengeFIAPLibrary.Domain.ValueObjects;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Commands.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Result<Unit>>
    {
        private readonly ICustomerRepository _customerRepository;

        public AddCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Result<Unit>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerName = new Name()
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var customerEmail = new Email()
            {
                Address = request.EmailAddress
            };

            var customerAddress = new Address()
            {
                City = request.City,
                Country = request.Country,
                HouseNumber = request.HouseNumber,
                State = request.State,
                Street = request.Street,
                ZipCode = request.ZipCode
            };

            var customer = new Customer(customerName, customerEmail, customerAddress);

            await _customerRepository.AddAsync(customer);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
