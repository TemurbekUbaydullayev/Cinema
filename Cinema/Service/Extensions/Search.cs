using Cinema.Domain.Enums;
using Cinema.Service.DTOs;
using Cinema.Service.Interfaces;
using Cinema.Service.Services;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Service.Extensions
{
    public static class Search
    {
        public static ICollection<MovieDto> SearchOfMovie(this string partOfWord)
        {
            IMovieService movieService = new MovieService();

            return movieService.GetAll().Where(p => p.Name.ToLower().Contains(partOfWord.ToLower())).ToList();
        }

        public static ICollection<MovieDto> SearchOfMovie(this string partOfWord, Genre genre)
        {
            IMovieService movieService = new MovieService();

            return movieService.GetAll().Where(p => p.Name.ToLower().Contains(partOfWord.ToLower()) && p.Genre == genre).ToList();
        }
    }
}
