using Cinema.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Service.Interfaces
{
    public interface IAudienceService
    {
        AudienceDto Create(AudienceDto entity);
        IEnumerable<AudienceDto> GetAll();
    }
}
