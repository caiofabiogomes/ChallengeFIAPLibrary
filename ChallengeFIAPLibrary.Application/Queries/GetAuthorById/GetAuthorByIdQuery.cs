﻿using ChallengeFIAPLibrary.Application.Abstraction;
using ChallengeFIAPLibrary.Application.ViewModels;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<Result<AuthorViewModel>>
    {
        public Guid Id { get; set; }
    }
}
