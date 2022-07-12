using Cinema.Service.DTOs;
using System.Collections.Generic;

namespace Cinema.Service.Interfaces
{
    public interface IAudienceService
    {
        AudienceDto Create(AudienceDto entity);
        IEnumerable<AudienceDto> GetAll();
    }
}
