using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WriteDbContext(serviceProvider.GetRequiredService<DbContextOptions<WriteDbContext>>()))
            {
                context.Database.Migrate();
            }
        }
    }
}
