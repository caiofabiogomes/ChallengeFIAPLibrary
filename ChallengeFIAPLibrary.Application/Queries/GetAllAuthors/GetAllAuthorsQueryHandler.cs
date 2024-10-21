using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using ChallengeFIAPLibrary.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFIAPLibrary.Application.Queries.GetAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, Result<List<AuthorViewModel>>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;

        }

        public async Task<Result<List<AuthorViewModel>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAllAsync();

            var authorsResult = _mapper.Map<List<AuthorViewModel>>(authors);

            return authorsResult;
        }
    }
}
