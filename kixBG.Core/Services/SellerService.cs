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
    public class SellerService : ISellerService
    {
        private readonly IRepository repository;

        public SellerService(IRepository _repository)
        {
            repository = _repository;
        }


        public async Task<bool> ExistsById(string userId)
        {
            return await repository.AllReadOnly<Seller>()
                .AnyAsync(s => s.UserId == userId);
        }

        public async Task<bool> PhoneNumberTaken(string phoneNumber)
        {
            return await repository.AllReadOnly<Seller>()
                .AnyAsync(s => s.PhoneNumber == phoneNumber);
        }
        public async Task AddAsync(string userId, string fullName, string phoneNumber, int cityId)
        {
            Seller sellerToAdd = new Seller()
            {
                UserId = userId,
                Name = fullName,
                PhoneNumber = phoneNumber,
                CityId = cityId
            };

            await repository.AddAsync(sellerToAdd);
            await repository.SaveChangesAsync();
        }

        public async Task<int> GetSellerIdByUserId(string userId)
        {
            return await repository.AllReadOnly<Seller>()
                .Where(s => s.UserId == userId)
                .Select(s => s.Id)
                .FirstAsync();
        }

        public async Task<string> GetUserIdBySellerId(int sellerId)
        {
            return await repository.AllReadOnly<Seller>()
                .Where(s => s.Id == sellerId)
                .Select(s => s.UserId)
                .FirstAsync();

        }
    }
}
