using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository
    {
        Task<Purchases> AddPurchase(Purchases purchase);
        Task<Purchases> GetPurchasesByUser(int userId);
    }
}
