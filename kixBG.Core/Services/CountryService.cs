using kixBG.Core.Contracts;
using kixBG.Infrastructure.Data.Common;
using kixBG.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace kixBG.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository repository;

        public CountryService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Country> GetCountryById(int id)
        {
            return await repository.All<Country>()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
