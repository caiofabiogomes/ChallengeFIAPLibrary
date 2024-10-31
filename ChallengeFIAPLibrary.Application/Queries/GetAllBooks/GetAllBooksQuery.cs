using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<Result<List<BookViewModel>>>
    {
    }
}
