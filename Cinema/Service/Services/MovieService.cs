using Cinema.Data.IRepositories;
using Cinema.Data.Repositories;
using Cinema.Domain.Entities;
using Cinema.Service.DTOs;
using Cinema.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        public MovieService()
        {
            movieRepository = new MovieRepository();
        }
        public MovieDto Create(MovieDto movie)
        {
            MovieDto movieCheck = GetAll().FirstOrDefault(p => p.Name.Equals(movie.Name));

            if (movieCheck != null)
                return null;

            var cinema = new Movie
            {
                Name = movie.Name,
                Genre = movie.Genre,
                Price = movie.Price,
                StartTime = movie.StartTime
            };

            return ConvertToViewModel(movieRepository.Create(cinema));
        }

        public bool Delete(long id)
                => movieRepository.Delete(id);

        public MovieDto Get(long id)
        {
            MovieDto movieCheck = GetAll().FirstOrDefault(p => p.Equals(id));

            if (movieCheck != null)
                return ConvertToViewModel(movieRepository.Get(id));

            return null;
        }

        public IEnumerable<MovieDto> GetAll()
            => movieRepository.GetAll().Select(p => new MovieDto
            {
                Id = p.Id,
                Name = p.Name,
                Genre = p.Genre,
                Price = p.Price,
                StartTime = p.StartTime,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });

        public MovieDto Update(MovieDto movie)
        {
            MovieDto movieCheck = GetAll().FirstOrDefault(p => p.Id == movie.Id);

            if (movieCheck is null)
                return null;

            var entity = new Movie
            {
                Id = movie.Id,
                Name = movie.Name,
                Genre = movie.Genre,
                Price = movie.Price,
                StartTime = movie.StartTime,
                CreatedAt = movie.CreatedAt,
                UpdatedAt = movie.UpdatedAt
            };

            return ConvertToViewModel((movieRepository.Update(entity)));
        }

        private MovieDto ConvertToViewModel(Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Price = movie.Price,
                Genre = movie.Genre,
                StartTime = movie.StartTime,
                UpdatedAt = movie.UpdatedAt,
                CreatedAt = movie.CreatedAt
            };
        }
    }
}
