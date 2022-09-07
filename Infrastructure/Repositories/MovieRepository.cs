using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

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

        public async Task<PagedResultSet<Movie>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int page = 1)
        {
            var totalMoviesCountOfGenre = await _movieShopDbContext.MovieGenres.Where(g => g.GenreId == genreId).CountAsync();
            if(totalMoviesCountOfGenre == 0)
            {
                throw new Exception("No Movies found for this genre");
            }

            var movies = await _movieShopDbContext.MovieGenres.Where(g => g.GenreId == genreId).Include(g => g.Movie)
                .OrderByDescending(m => m.Movie.Revenue)
                .Select(m => new Movie
                {
                    Id = m.MovieId, 
                    PosterUrl = m.Movie.PosterUrl, 
                    Title = m.Movie.Title
                })
                .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var pagedMovies = new PagedResultSet<Movie>(movies, page, pageSize, totalMoviesCountOfGenre);
            return pagedMovies;
        }
    }
}
