using kixBG.Core.Contracts;
using kixBG.Infrastructure.Data.Common;
using kixBG.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Core.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository repository;

        public CityService(IRepository repository)
        {
            this.repository = repository;
        }

        public int FindIdByName(string name)
        {
            return repository.FindCityByName(name).First();
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await repository
                .All<City>()
                .ToListAsync(); 
        }
    }
}
