using Cinema.Domain.Entities;
using System.Collections.Generic;

namespace Cinema.Data.IRepositories
{
    public interface IAdminRepository
    {
        Admin Create(Admin admin);
        Admin Update(Admin admin);
        bool Delete(long id);
        Admin Get(long id);
        IEnumerable<Admin> GetAll();
    }
}
