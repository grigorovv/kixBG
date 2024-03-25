using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Core.Contracts
{
    public interface ICityService
    {
        Task<List<string>> GetAllAsync();
        int FindByName(string name);
    }
}
