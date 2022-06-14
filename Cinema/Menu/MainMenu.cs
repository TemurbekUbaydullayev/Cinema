using Cinema.Service.DTOs;
using Cinema.Service.Extensions;
using Cinema.Service.Interfaces;
using Cinema.Service.Services;
using System;

namespace Cinema.Menu
{
    public class MainMenu
    {
        public void Menu()
        {
            while(true)
            {
                Console.Write("\nAdminstratsiya(1) | Client(2) | Exit programm(3)\n >>> ");

                string input = Console.ReadLine();

                if(input == "1")
                {
                    Console.Clear();

                    AdminForCreationDto adminForCreationDto = new AdminForCreationDto();
                    IAdminService adminService = new AdminService();

                    Console.Write($"Emailingizni kiriting: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    adminForCreationDto.Email = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Parolingizni kiriting: ");
                    adminForCreationDto.Password = adminService.ReadPassword();

                    bool result = adminForCreationDto.Password.Login(adminForCreationDto.Email);
                    if(result == true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tMuvaffaqqiyatli o'tildi\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        //MissionAdmin();
                    }
                    else
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tEmail yoki parol xato!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }



                }
                else if(input == "2")
                {

                }
                else if (input == "3")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNothing Found\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        } 

        public void MissionAdmin()
        {
            while(true)
            {
                Console.Write("\nKino(1) | Adminstrator sozlamalari(2) | Asosiy Menu(3)\n >>> ");
                string input = Console.ReadLine();

                if(input == "1")
                {
                    Console.Clear();
                    MovieMenu();
                }
                else if(input == "2")
                {
                    Console.Clear();
                    AdminMenu();
                }
                else if(input == "3")
                {
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNothing Found\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public void AdminMenu()
        {

            while(true)
            {
                Console.Write("Add Admin(1) | Delete Admin(2) | Admin lists(3) | Go back(4)\n >>> ");
                string inputAdminSelect = Console.ReadLine();

                
            }
        }

        public void MovieMenu()
        {
            while(true)
            {
                 
            }
        }
    }
}
