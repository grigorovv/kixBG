using kixBG.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Core.Services
{
    public class SellerService : ISellerService
    {
        public Task<bool> ExistsById(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PhoneNumberTaken(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
