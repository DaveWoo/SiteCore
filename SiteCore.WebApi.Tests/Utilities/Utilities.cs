using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApiSample.DataAccess;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Tests
{
    public static class Utilities
    {
        public static PetsRepository Repos = new PetsRepository(new SiteCoreContext(Utilities.TestDbContextOptions()));

        #region snippet1
        public static DbContextOptions<SiteCoreContext> TestDbContextOptions()
        {
            // Create a new service provider to create a new in-memory database.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance using an in-memory database and 
            // IServiceProvider that the context should resolve all of its 
            // services from.
            var builder = new DbContextOptionsBuilder<SiteCoreContext>()
                .UseInMemoryDatabase("InMemoryDb")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
        #endregion
    }
}
