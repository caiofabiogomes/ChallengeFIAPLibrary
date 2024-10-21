using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFIAPLibrary.Application.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<Result<AuthorViewModel>>
    {
        public Guid Id { get; set; }
    }
}
