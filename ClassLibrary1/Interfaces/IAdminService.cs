using Cinema.Service.DTOs;
using System.Collections.Generic;

namespace Cinema.Service.Interfaces
{
    public interface IAdminService
    {
        AdminViewModel Create(AdminForCreationDto admin);
        AdminViewModel Update(AdminForCreationDto admin);
        bool Delete(long id);
        AdminViewModel Get(long id);
        IEnumerable<AdminViewModel> GetAll();
        string ReadPassword();
    }
}
