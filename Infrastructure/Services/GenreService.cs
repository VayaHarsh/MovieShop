using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<List<GenreModel>> GetAllGenre()
        {
            var genres = await _genreRepository.GetAllGenres();

            var genresModel = genres.Select(g => new GenreModel { Id = g.Id, Name = g.Name }).ToList();

            return genresModel;
        }

        public Task<GenreModel> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        Task<List<GenreModel>> IGenreService.GetAllGenres()
        {
            throw new NotImplementedException();
        }
    }
}
