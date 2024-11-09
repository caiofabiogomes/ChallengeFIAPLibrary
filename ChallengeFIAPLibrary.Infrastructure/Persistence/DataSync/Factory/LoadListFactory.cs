using ChallengeFIAPLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.DataSync.Factory
{
    public class LoadListFactory 
    {
        public IEntityFactory<TEntity> GetFactory<TEntity>() where TEntity : BaseEntity, new()
        {
            switch (typeof(TEntity))
            { 
                case Type t when t == typeof(Book):
                    return new BookFactory() as IEntityFactory<TEntity>;
                default:
                    return null;
            }
        }
    }
}
