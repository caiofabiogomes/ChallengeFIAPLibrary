using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Result<BookViewModel>>
    {
        public Guid Id { get; set; }
    }
}
