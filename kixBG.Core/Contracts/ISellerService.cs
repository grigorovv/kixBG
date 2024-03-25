using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Core.Contracts
{
    public interface ISellerService
    {
        Task<bool> ExistsById(string userId);
        Task<bool> PhoneNumberTaken(string phoneNumber);
    }
}
