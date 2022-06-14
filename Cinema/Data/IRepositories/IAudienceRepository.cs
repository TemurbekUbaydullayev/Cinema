using Cinema.Domain.Entities;
using System.Collections.Generic;

namespace Cinema.Data.IRepositories
{
    public interface IAudienceRepository
    {
        Audience Create(Audience audience);
        IEnumerable<Audience> GetAll();
    }
}
