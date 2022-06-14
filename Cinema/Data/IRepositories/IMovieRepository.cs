using Cinema.Domain.Entities;
using System.Collections.Generic;

namespace Cinema.Data.IRepositories
{
    public interface IMovieRepository
    {
        Movie Create(Movie admin);
        Movie Update(Movie admin);
        bool Delete(long id);
        Movie Get(long id);
        IEnumerable<Movie> GetAll();
    }
}
