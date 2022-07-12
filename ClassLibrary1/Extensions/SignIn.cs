using Cinema.Data.Repositories;
using System.Linq;

namespace Cinema.Service.Extensions
{
    public static class SignIn
    {
        public static bool Login(this string password, string email)
            => new AdminRepository().GetAll().Where(p => p.Password == password.GetHashPassword() && p.Email == email).Any();

    }
}
