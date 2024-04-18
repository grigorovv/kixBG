using kixBG.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Core.Contracts
{
    public interface ICityService
    {
        Task<List<City>> GetAllAsync();
        int FindIdByName(string name);
    }
}
