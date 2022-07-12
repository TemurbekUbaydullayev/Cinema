using Cinema.Service.DTOs;
using System.Collections.Generic;

namespace Cinema.Service.Interfaces
{
    public interface IMovieService
    {
        MovieDto Create(MovieDto movie);
        MovieDto Update(MovieDto movie);
        bool Delete(long id);
        MovieDto Get(long id);
        IEnumerable<MovieDto> GetAll();
    }
}
