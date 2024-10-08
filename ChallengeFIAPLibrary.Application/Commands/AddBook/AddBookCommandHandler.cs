using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Commands.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Result<Unit>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Result<Unit>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.AuthorId);

            if (author is null) 
                return Result<Unit>.Failure("Author not found");

            var book = new Book(request.Title,request.Description, request.StockQuantity, request.AuthorId);

            await _bookRepository.AddAsync(book);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
