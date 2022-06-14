using Cinema.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
