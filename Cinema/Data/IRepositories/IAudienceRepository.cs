using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.IRepositories
{
    public interface IAudienceRepository
    {
        Audience Create(Audience audience);
        IEnumerable<Audience> GetAll();
    }
}
