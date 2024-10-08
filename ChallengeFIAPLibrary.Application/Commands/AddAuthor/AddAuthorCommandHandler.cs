using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;
using ChallengeFIAPLibrary.Domain.ValueObjects;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Commands.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Result<Unit>>
    {
        private readonly IAuthorRepository _authorRepository;

        public AddAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<Result<Unit>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorName = new Name()
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var authorEmail = new Email()
            {
                Address = request.EmailAddress
            };
            
            var authorAddress = new Address()
            {
                City = request.City,
                Country = request.Country,
                HouseNumber = request.HouseNumber,
                State = request.State,
                Street = request.Street,
                ZipCode = request.ZipCode
            };

            var author = new Author(authorName, authorEmail, authorAddress);

            await _authorRepository.AddAsync(author);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
