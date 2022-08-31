using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CastRepository : ICastRepository
    {
        private MovieShopDbContext _movieShopDbContext;
        public CastRepository(MovieShopDbContext dbContext)
        {
            _movieShopDbContext = dbContext;
        }
        public async Task<Cast> GetById(int id)
        {
            var castDetails = await _movieShopDbContext.Cast
            .Include(castDetails => castDetails.MoviesOfCast).ThenInclude(castDetails => castDetails.Movie)
            .FirstOrDefaultAsync(castDetails => castDetails.Id == id);
            return castDetails;
        }

    }
}
