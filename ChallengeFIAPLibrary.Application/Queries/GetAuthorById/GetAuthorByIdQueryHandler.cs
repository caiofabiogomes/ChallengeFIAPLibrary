﻿using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using ChallengeFIAPLibrary.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFIAPLibrary.Application.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Result<AuthorViewModel>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;

        }

        public async Task<Result<AuthorViewModel>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.Id);

            if (author == null)
                return Result<AuthorViewModel>.NotFound("Author not found");

            var authorResult = _mapper.Map<AuthorViewModel>(author);

            return Result<AuthorViewModel>.Success(authorResult);
        }
    }
}
