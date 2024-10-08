using ChallengeFIAPLibrary.Application.Abstraction;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Commands.AddBook
{
    public class AddBookCommand : IRequest<Result<Unit>>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public Guid AuthorId { get; set; }
    }
}
