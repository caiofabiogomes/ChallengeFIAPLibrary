using AutoMapper;
using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using ChallengeFIAPLibrary.Domain.Repositories;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, Result<List<CustomerViewModel>>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<CustomerViewModel>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            var customersResult = _mapper.Map<List<CustomerViewModel>>(customers);

            return Result<List<CustomerViewModel>>.Success(customersResult);
        }
    }
}
