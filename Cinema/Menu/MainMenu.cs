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
            while (true)
            {
                Console.Write("\nAdminstratsiya(1) | Kino(2) | Dasturdan chiqish(3)\n >>> ");

                string input = Console.ReadLine();

                if (input == "1")
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
                    if (result == true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tMuvaffaqqiyatli o'tildi\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        MissionAdmin();
                    }
                    else
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tEmail yoki parol xato!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }



                }
                else if (input == "2")
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
            while (true)
            {
                Console.Write("\nKino(1) | Adminstrator sozlamalari(2) | Asosiy Menu(3)\n >>> ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();
                    MovieMenu();
                }
                else if (input == "2")
                {
                    Console.Clear();
                    AdminMenu();
                }
                else if (input == "3")
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

            IAdminService adminService = new AdminService();
            AdminForCreationDto adminForCreationDto = new AdminForCreationDto();

            while (true)
            {
                Console.Write("Admin qo'shish(1) | Adminni o'chirish(2) | Adminni yangilash(3) | Adminlar ro'yxati(4) | Go back(5)\n >>> ");
                string inputAdminSelect = Console.ReadLine();

                if (inputAdminSelect == "1")
                {
                    Console.Clear();

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("    Admin ma'lumotlarini kiriting:\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("Ismni kiriting: ");
                        adminForCreationDto.FirstName = Console.ReadLine();
                        adminForCreationDto.FirstName = adminForCreationDto.FirstName.GetCapitalize();

                        Console.Write("Familiyani kiritng: ");
                        adminForCreationDto.LastName = Console.ReadLine();
                        adminForCreationDto.LastName = adminForCreationDto.LastName.GetCapitalize();

                        Console.Write("Yoshni kiriting: ");
                        adminForCreationDto.Age = int.Parse(Console.ReadLine());

                        Console.Write("Telefon raqam kiriting: ");
                        adminForCreationDto.Phone = Console.ReadLine();

                        Console.Write("Emailni kiriting: ");
                        adminForCreationDto.Email = Console.ReadLine();

                        Console.Write("Parol yarating: ");
                        adminForCreationDto.Password = Console.ReadLine();
                        adminForCreationDto.Password = adminForCreationDto.Password.GetHashPassword();

                        var newAdmin = adminService.Create(adminForCreationDto);

                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{adminForCreationDto.FirstName} adminlar safiga muvaffaqqiyatli qo'shildi\n\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        AdminMenu();
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nXatolik yuz berdi, qayta urinib ko'ring\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (inputAdminSelect == "2")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("    O'chirilishi kerak bo'lgan adminning id raqamini kiriting:\n>>> ");
                    Console.ForegroundColor = ConsoleColor.White;

                    adminForCreationDto.Id = long.Parse(Console.ReadLine());

                    bool result = adminService.Delete(adminForCreationDto.Id);

                    if (result == true)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Admin muvaffaqqiyatli o'chirildi\n\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        AdminMenu();
                    }
                    else
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"Kechirasiz bizda id raqami {adminForCreationDto.Id} bo'lgan admin mavjud emas, qaytadan urinib ko'ring \n\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        AdminMenu();
                    }
                }
                else if (inputAdminSelect == "3")
                {
                    Console.Clear();

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Admin ma'lumotlariga o'zgartirish uchun ma'lumotlarni qayta kiriting:\n\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("Id raqamni kiriting: ");
                        adminForCreationDto.Id = long.Parse(Console.ReadLine());

                        Console.Write("Ismni kiriting: ");
                        adminForCreationDto.FirstName = Console.ReadLine();
                        adminForCreationDto.FirstName = adminForCreationDto.FirstName.GetCapitalize();

                        Console.Write("Familiyani kiritng: ");
                        adminForCreationDto.LastName = Console.ReadLine();
                        adminForCreationDto.LastName = adminForCreationDto.LastName.GetCapitalize();

                        Console.Write("Yoshni kiriting: ");
                        adminForCreationDto.Age = int.Parse(Console.ReadLine());

                        Console.Write("Telefon raqam kiriting: ");
                        adminForCreationDto.Phone = Console.ReadLine();

                        Console.Write("Emailni kiriting: ");
                        adminForCreationDto.Email = Console.ReadLine();

                        Console.Write("Parolni kiriting: ");
                        adminForCreationDto.Password = Console.ReadLine();
                        adminForCreationDto.Password = adminForCreationDto.Password.GetHashPassword();

                        var newAdmin = adminService.Update(adminForCreationDto);

                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"Ushbu admin ma'lumotlari qayta yozildi.\n\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        AdminMenu();

                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nXatolik yuz berdi, qayta urinib ko'ring\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (inputAdminSelect == "4")
                {
                    Console.Clear();

                    try
                    {
                        var admins = adminService.GetAll();

                        //ConsoleTable adminTable = new ConsoleTable("Id", "Admin", "Age", "Phone", "Email");
                        foreach (var admin in admins)
                        {
                            if (admin.FirstName != "" && admin.LastName != null)
                            {
                                adminTable.AddRow(admin.FirstName + " " + admin.LastName,
                                    admin.Age,
                                    admin.Phone,
                                    admin.Email
                                    );
                            }
                        }

                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nXatolik yuz berdi, qayta urinib ko'ring\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (inputAdminSelect == "5")
                {

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

        public void MovieMenu()
        {
            while (true)
            {

            }
        }
    }
}