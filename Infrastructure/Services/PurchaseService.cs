using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public async Task<int> PurchaseMovie(PurchaseModel Model)
        {
                // check if the email exists in the database
                // go to user table using UserRepository
                var purchase = await _purchaseRepository.GetPurchasesByUser(Model.UserId);
                if (purchase != null)
                {
                    throw new Exception("Movie already purchased");
                }

            // create new User entity object and save it to database using EF Core SaveChanges method
                var dbPurchase = new Purchases
                {
                    MovieId = Model.MovieId,
                    UserId = Model.UserId,
                    TotalPrice = Model.TotalPrice
                };

                var createdUser = await _purchaseRepository.AddPurchase(dbPurchase);
                return dbPurchase.PurchaseNumber;
        }
        
    }
}
