using ChallengeFIAPLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Reflection;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence
{
    public class WriteDbContext(DbContextOptions<WriteDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(BaseEntity).IsAssignableFrom(entityType.ClrType)) 
                    continue;

                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var filter = Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, nameof(BaseEntity.IsDeleted)),
                        Expression.Constant(false)),
                    parameter);
                entityType.SetQueryFilter(filter);

                var method = modelBuilder.Entity(entityType.ClrType).GetType().GetMethod("HasIndex", new[] { typeof(string) });
                
                if (method == null) 
                    continue;

                var indexBuilder = method.Invoke(modelBuilder.Entity(entityType.ClrType), new object[] { nameof(BaseEntity.IsDeleted) });
                var hasFilterMethod = indexBuilder?.GetType().GetMethod("HasFilter");
                hasFilterMethod?.Invoke(indexBuilder, new object[] { $"{nameof(BaseEntity.IsDeleted)} = 0" });
            }
        }

        public override int SaveChanges()
        {
            HandleSoftDelete();
            UpdateLastUpdated();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleSoftDelete();
            UpdateLastUpdated();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateLastUpdated()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e is { Entity: BaseEntity, State: EntityState.Modified });

            foreach (var entry in entries)
            {
                ((BaseEntity)entry.Entity).Update();
            }
        }

        private void HandleSoftDelete()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e is { State: EntityState.Deleted, Entity: BaseEntity });

            foreach (var entry in entries)
            {
                entry.State = EntityState.Modified;
                ((BaseEntity)entry.Entity).Delete();
            }
        }

    }
}
