using kixBG.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace kixBG.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static MainDbContext Instance
        {
            get
            {
                var options = new DbContextOptionsBuilder<MainDbContext>()
                        .UseInMemoryDatabase("InMemoryDatabase" + DateTime.Now.Ticks.ToString())
                        .Options;

                return new MainDbContext(options);
            }
        }
    }
}
