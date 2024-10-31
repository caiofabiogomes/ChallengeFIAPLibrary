using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<Result<List<CustomerViewModel>>>
    {
    }
}
