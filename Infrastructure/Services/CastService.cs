using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService()
        {
        }

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        CastDetailsModel ICastService.GetCastDetails(int castId)
        {
            var castDetails = _castRepository.GetById(castId);

            var castDetailsModel = new CastDetailsModel
            {
                Id = castDetails.Id,
                Name = castDetails.Name,
                Gender = castDetails.Gender,
                ProfilePath = castDetails.ProfilePath
            };

            foreach (var cast in castDetails.MoviesOfCast)
            {
                castDetailsModel.Movies.Add(new MovieCardModel
                {
                    Id = cast.MovieId,
                    Title = cast.Movie.Title
                });
            }

            return castDetailsModel;
        }
    }
}
