using Cinema.Domain.Enums;
using Cinema.Service.DTOs;
using Cinema.Service.Extensions;
using Cinema.Service.Interfaces;
using Cinema.Service.Services;
using System;
using System.Linq;

namespace Cinema.Menu
{
    public class MainMenu
    {
        public void Menu()
        {
            while (true)
            {
                Console.Write("\nAdminstratsiya(1) | Xaridlar bo'limi(2) | Dasturdan chiqish(3)\n >>> ");

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
                    Console.Clear();

                    MovieDto movieDto = new MovieDto();
                    MovieService movieService = new MovieService();

                    Console.Write("\nJanrlar(1) | Barchasini ko'rish(2) | Umumiy qidiruv(3) | Ortga qaytish(4)\n >>> ");
                    string inp = Console.ReadLine();

                    if(inp == "1")
                    {
                        Console.Clear();

                        MovieGenre();
                    }

                    else if(inp == "2")
                    {
                        Console.Clear();

                        try
                        {
                            var movies = movieService.GetAll();
                            foreach (var movie in movies)
                                Console.WriteLine($"{movie.Id} - {movie.Name} - {movie.Genre} - {movie.Price} - {movie.StartTime}\n");

                            Console.Write($"Agar biror kino chiptasini sotib olishni istasangiz uning oldidagi raqamini kiriting:\n>>>");

                            ByTicket(long.Parse(Console.ReadLine()));
                        }

                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nXatolik yuz berdi, qayta urinib ko'ring\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    else if(inp == "3")
                    {
                        Console.Clear();

                        try
                        {
                            Console.WriteLine($"Qidiruvni boshlang: ");
                            var movies = Console.ReadLine().SearchOfMovie();

                            foreach (var movie in movies)
                                Console.WriteLine($"{movie.Id} - {movie.Name} - {movie.Genre} - {movie.Price} - {movie.StartTime}\n");

                            Console.Write($"Agar biror kino chiptasini sotib olishni istasangiz uning oldidagi raqamini kiriting:\n>>>");

                            ByTicket(long.Parse(Console.ReadLine()));
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nXatolik yuz berdi, qayta urinib ko'ring\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    else if(inp == "4")
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
                else if (input == "3")
                {
                    Console.Clear();
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
                Console.Write("Admin qo'shish(1) | Adminni o'chirish(2) | Adminni yangilash(3) | Adminlar ro'yxati(4) | Ortga qaytish(5)\n >>> ");
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

                        Console.Write("Familiyani kiriting: ");
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
                        Console.Write($"{newAdmin.FirstName} adminlar safiga muvaffaqqiyatli qo'shildi\n\n");
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
                        Console.Write($"{newAdmin.FirstName}ning ma'lumotlari qayta yozildi.\n\n");
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
                        foreach (var admin in admins)
                        {
                            Console.WriteLine($"{admin.Id} - {admin.FirstName} {admin.LastName} - {admin.Age} - {admin.Email}");
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
                    Console.Clear();
                    MissionAdmin();
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
                IMovieService movieService = new MovieService();
                MovieDto movieDto = new MovieDto();

                while (true)
                {
                    Console.Write("Kino qo'shish(1) | Kinoni o'chirish(2) | Kinoni yangilash(3) | Kinolar ro'yxati(4) | Ortga qaytish(5)\n >>> ");
                    string inputAdminSelect = Console.ReadLine();

                    if (inputAdminSelect == "1")
                    {
                        Console.Clear();

                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("    Kino ma'lumotlarini kiriting:\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Write("Kino nomini kiriting: ");
                            movieDto.Name = Console.ReadLine();
                            movieDto.Name = movieDto.Name.GetCapitalize();

                            Console.Write("Janrni tanlang (classic(1), drama(2), history(3), comedy(4)): ");
                            int input = int.Parse(Console.ReadLine());
                            if (input == 1)
                                movieDto.Genre = Genre.Classic;
                            else if (input == 2)
                                movieDto.Genre = Genre.Drama;
                            else if (input == 3)
                                movieDto.Genre = Genre.History;
                            else if (input == 4)
                                movieDto.Genre = Genre.Comedy;

                            Console.Write("Chipta narxini kiriting: ");
                            movieDto.Price = decimal.Parse(Console.ReadLine());

                            Console.Write("Kino boshlanish vaqtini kiriting: ");
                            movieDto.StartTime = Console.ReadLine();

                            var newMovie = movieService.Create(movieDto);

                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{newMovie.Name} nomli kino ma'lumotlari muvaffaqqiyatli qo'shildi\n\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            MovieMenu();
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
                        Console.Write("    O'chirilishi kerak bo'lgan kinoning id raqamini kiriting:\n>>> ");
                        Console.ForegroundColor = ConsoleColor.White;

                        movieDto.Id = long.Parse(Console.ReadLine());

                        bool result = movieService.Delete(movieDto.Id);

                        if (result == true)
                        {
                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Kino muvaffaqqiyatli o'chirildi\n\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            MovieMenu();
                        }
                        else
                        {
                            Console.Clear();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"Kechirasiz bizda id raqami {movieDto.Id} bo'lgan kino mavjud emas, qaytadan urinib ko'ring \n\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            MovieMenu();
                        }
                    }
                    else if (inputAdminSelect == "3")
                    {
                        Console.Clear();

                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Kino ma'lumotlariga o'zgartirish uchun ma'lumotlarni qayta kiriting:\n\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.Write("Id: ");
                            movieDto.Id = long.Parse(Console.ReadLine());

                            Console.Write("Kino nomi: ");
                            movieDto.Name = Console.ReadLine();
                            movieDto.Name = movieDto.Name.GetCapitalize();

                            Console.Write("Janr (classic(1), drama(2), history(3), comedy(4)): ");
                            int input = int.Parse(Console.ReadLine());
                            if (input == 1)
                                movieDto.Genre = Genre.Classic;
                            else if (input == 2)
                                movieDto.Genre = Genre.Drama;
                            else if (input == 3)
                                movieDto.Genre = Genre.History;
                            else if (input == 4)
                                movieDto.Genre = Genre.Comedy;

                            Console.Write("Chipta narxi: ");
                            movieDto.Price = decimal.Parse(Console.ReadLine());

                            Console.Write("Kino boshlanish vaqti: ");
                            movieDto.StartTime = Console.ReadLine();


                            Console.Clear();

                            var newMovie = movieService.Update(movieDto);


                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"Ushbu {newMovie.Name} nomli kino ma'lumotlari qayta yozildi.\n\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            MovieMenu();

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
                            var movies = movieService.GetAll();
                            foreach (var movie in movies)
                            {
                                Console.WriteLine($"{movie.Id} - {movie.Name} - {movie.Genre} - {movie.Price} - {movie.StartTime}\n");
                            }

                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nXatolik yuz berdi, qayta urinib ko'ring\n\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else if (inputAdminSelect == "5")
                    {
                        Console.Clear();
                        MissionAdmin();
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
        }

        private void ByTicket(long id)
        {
            Console.Clear();

            IMovieService movieService = new MovieService();

            AudienceDto audienceDto = new AudienceDto();

            IAudienceService audienceService = new AudienceService();

            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Xaridni amalga oshirish uchun ba'zi malumotlaringizni kiritishingiz zarur:\n\n");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Ismingizni kiriting: ");
                audienceDto.FirstName = Console.ReadLine();
                audienceDto.FirstName = audienceDto.FirstName.GetCapitalize();

                Console.Write("Familiyangizni kiritng: ");
                audienceDto.LastName = Console.ReadLine();
                audienceDto.LastName = audienceDto.LastName.GetCapitalize();

                Console.Write("Emailingizni kiriting: ");
                audienceDto.Email = Console.ReadLine();

                audienceDto.MovieName = movieService.Get(id).Name;

                var audience = audienceService.Create(audienceDto);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\n{audience.FirstName} xaridingiz muvaffaqqiyatli amalga oshirildi\n\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nXatolik yuz berdi, qayta urinib ko'ring\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private void MovieGenre()
        {
            IMovieService movieService = new MovieService();

            while(true)
            {
                Console.Write($"\nKlassik(1) | Drama(2) | Tarixiy(3) | Komediya(4) | Asosiy Menu(5)\n>>>");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();

                    var classicMovies = movieService.GetAll().Where(p => p.Genre == Genre.Classic);

                    foreach (var movie in classicMovies)
                        Console.WriteLine($"{movie.Id} - {movie.Name} - {movie.Genre} - {movie.Price} - {movie.StartTime}");

                    Console.Write($"Agar biror kino chiptasini sotib olishni istasangiz uning oldidagi raqamini kiriting:\n>>>");

                    ByTicket(long.Parse(Console.ReadLine()));

                }
                else if (input == "2")
                {
                    Console.Clear();

                    var classicMovies = movieService.GetAll().Where(p => p.Genre == Genre.Drama);

                    foreach (var movie in classicMovies)
                        Console.WriteLine($"{movie.Id} - {movie.Name} - {movie.Genre} - {movie.Price} - {movie.StartTime}");

                    Console.Write($"Agar biror kino chiptasini sotib olishni istasangiz uning oldidagi raqamini kiriting:\n>>>");

                    ByTicket(long.Parse(Console.ReadLine()));
                }
                else if (input == "3")
                {
                    Console.Clear();

                    var classicMovies = movieService.GetAll().Where(p => p.Genre == Genre.History);

                    foreach (var movie in classicMovies)
                        Console.WriteLine($"{movie.Id} - {movie.Name} - {movie.Genre} - {movie.Price} - {movie.StartTime}");

                    Console.Write($"Agar biror kino chiptasini sotib olishni istasangiz uning oldidagi raqamini kiriting:\n>>>");

                    ByTicket(long.Parse(Console.ReadLine()));
                }
                else if (input == "4")
                {
                    Console.Clear();

                    var classicMovies = movieService.GetAll().Where(p => p.Genre == Genre.Comedy);

                    foreach (var movie in classicMovies)
                        Console.WriteLine($"{movie.Id} - {movie.Name} - {movie.Genre} - {movie.Price} - {movie.StartTime}");

                    Console.Write($"Agar biror kino chiptasini sotib olishni istasangiz uning oldidagi raqamini kiriting:\n>>>");

                    ByTicket(long.Parse(Console.ReadLine()));
                }
                else if (input == "5")
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
    }
}