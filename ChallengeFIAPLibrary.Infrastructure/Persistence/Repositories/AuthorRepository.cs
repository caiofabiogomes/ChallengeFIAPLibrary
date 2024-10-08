using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeFIAPLibrary.Domain.Entities;
using ChallengeFIAPLibrary.Domain.Repositories;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Repositories
{
    public class AuthorRepository(WriteDbContext context) : AbstractRepository<Author>(context), IAuthorRepository;
}
