using Cinema.Service.DTOs;
using Cinema.Service.Interfaces;
using Cinema.Service.Services;
using System;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IAdminService adminService = new AdminService();

            AdminForCreationDto adminDto = new AdminForCreationDto()
            {
                Id = 2,
                FirstName = "Otabek",
                LastName = "Sandiyev",
                Age = 22,
                Phone = "+998973452132",
                Email = "otabek@gmail.com",
                Password = "otash"
            };

            var admin = adminService.Update(adminDto);

            Console.WriteLine($"{admin.Id} {admin.CreatedAt} {admin.FirstName}");
        }
    }
}
