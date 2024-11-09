using ChallengeFIAPLibrary.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.DataSync.Factory
{
    public class BookFactory : IEntityFactory<Book>
    {
        public BookFactory()
        {
        }

        public async Task<List<Book>> LoadAssociatedCollectionsAsync(Guid associationId, SqlConnection connection)
        {
            var booksSql = "SELECT * FROM Books WHERE AuthorId = @AuthorId";
            var books = await connection.QueryAsync<Book>(booksSql, new { AuthorId = associationId });
            
            return books.ToList();
        }
    }
}
