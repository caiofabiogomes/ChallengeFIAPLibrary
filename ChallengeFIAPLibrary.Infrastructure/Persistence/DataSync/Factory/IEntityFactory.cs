using ChallengeFIAPLibrary.Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.DataSync.Factory
{
    public interface IEntityFactory<T> where T : BaseEntity
    {
        Task<List<T>> LoadAssociatedCollectionsAsync(Guid associationId, SqlConnection connection);
    }
}
