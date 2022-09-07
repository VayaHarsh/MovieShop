using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository
    { 

        Task<List<Movie>> GetTop30GrossingMovies();
        Task<Movie> GetById(int id);

        Task<PagedResultSet<Movie>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int page = 1);
    }
}