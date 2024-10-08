using ChallengeFIAPLibrary.Application.Abstraction;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Commands.AddAuthor
{
    public class AddAuthorCommand : IRequest<Result<Unit>>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }
    }
}
