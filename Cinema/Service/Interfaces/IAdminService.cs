using Cinema.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Service.Interfaces
{
    public interface IAdminService
    {
        AdminViewModel Create(AdminForCreationDto admin);
        AdminViewModel Update(AdminForCreationDto admin);
        bool Delete(long id);
        AdminViewModel Get(long id);
        IEnumerable<AdminViewModel> GetAll();
    }
}
