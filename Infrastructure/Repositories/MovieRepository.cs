using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private MovieShopDbContext _movieShopDbContext;
        public MovieRepository(MovieShopDbContext dbContext)
        {
            _movieShopDbContext = dbContext;
        }
        public async Task<List<Movie>> GetTop30GrossingMovies()
        {
            var movies = await _movieShopDbContext.Movies.OrderByDescending(mbox => mbox.Revenue).Take(30).ToListAsync();
            return movies;
        }
        
        public async Task<Movie> GetById(int id)
        {
            
            var movieDetails = await _movieShopDbContext.Movies
            .Include(m => m.GenresOfMovie).ThenInclude(movieDetails => movieDetails.Genre)
            .Include(movieDetails => movieDetails.CastsOfMovie).ThenInclude(m => m.Cast)
            .Include(movieDetails=> movieDetails.Trailers)
            .FirstOrDefaultAsync(movieDetails => movieDetails.Id == id);
            return movieDetails;
        }
        
        public Movie GetTop30GrossingMovie(int id)
        {
            throw new NotImplementedException();
        }
    }
}
