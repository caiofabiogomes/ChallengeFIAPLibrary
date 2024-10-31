using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Queries.GetAuthors
{
    public class GetAllAuthorsQuery : IRequest<Result<List<AuthorViewModel>>>
    {
    }
}
