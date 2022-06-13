using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
