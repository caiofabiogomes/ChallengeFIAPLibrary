using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFIAPLibrary.Application.Queries.GetAuthors
{
    public class GetAllAuthorsQuery : IRequest<Result<List<AuthorViewModel>>>
    {
    }
}
