using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Result<CustomerViewModel>>
    {
        public Guid Id { get; set; }
    }
}
