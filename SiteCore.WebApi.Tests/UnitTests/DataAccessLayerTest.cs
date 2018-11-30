using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiSample.DataAccess;
using WebApiSample.DataAccess.Models;
using WebApiSample.Tests;
using Xunit;

namespace WebApiSample.Tests.UnitTests
{
    public class DataAccessLayerTest
    {
        [Fact]
        public async Task GetMessagesAsync_MessagesAreReturned()
        {
            using (var db = new SiteCoreContext(Utilities.TestDbContextOptions()))
            {
                // Arrange  
                var resultBefore = await Utilities.Repos.GetPetsAsync();
                var pet = await Utilities.Repos.AddPetAsync(new Pet
                {
                    Name = "Qi",
                    Breed = "Dave",
                    PetType = PetType.Dog,
                    StartDate=System.DateTime.Now
                });

                await db.SaveChangesAsync();

                // Act
                var resultAfter = await Utilities.Repos.GetPetsAsync();

                // Assert
                var actualMessages = Assert.IsAssignableFrom<List<Pet>>(resultAfter);            }
        }
    }
}
