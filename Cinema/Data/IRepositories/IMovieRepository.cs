using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
