﻿using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly MovieShopDbContext _dbContext;
        public PurchaseRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Purchases> AddPurchase(Purchases purchase)
        {

            _dbContext.Purchases.Add(purchase);
            await _dbContext.SaveChangesAsync();
            return purchase;
        }

        public async Task<Purchases> GetPurchasesByUser(int userId)
        {
            var purchase = await _dbContext.Purchases.FirstOrDefaultAsync(u => u.UserId == userId);
            return purchase;
        }
    }
}
