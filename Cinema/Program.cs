using Cinema.Menu;
using System;

namespace Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"    <<<< Kinoteatrimizga xush kelibsiz >>>>");

            Console.ForegroundColor = ConsoleColor.White;

            new MainMenu().Menu();


            #region nimadir
            //IAdminService adminService = new AdminService();

            //AdminForCreationDto adminDto = new AdminForCreationDto()
            //{
            //    Id = 2,
            //    FirstName = "Otabek",
            //    LastName = "Sandiyev",
            //    Age = 22,
            //    Phone = "+998973452132",
            //    Email = "otabek@gmail.com",
            //    Password = "otash"
            //};

            //var admin = adminService.Update(adminDto);

            //Console.WriteLine($"{admin.Id} {admin.CreatedAt} {admin.FirstName}");

            //IMovieService movieService = new MovieService();

            //MovieDto movieDto = new MovieDto()
            //{
            //    Name = "Jumanji",
            //    Description = "Galivut kinosi",
            //    Price = 11900,
            //    Genre = Genre.Comedy,
            //    StartTime = "Mon, 13 - 00"
            //};

            //var movie = movieService.Create(movieDto);

            //Console.WriteLine($"{movie.Id} {movie.CreatedAt} {movie.Name}");

            //var res = "Um".SearchOfMovie();

            ////foreach (var item in res)
            //Console.WriteLine($"{res[0]}");

            //IAdminRepository admin = new AdminRepository();

            //var res = admin.Get(2);

            //var result = "temur".Login("otabek@gmail.com");

            //Console.WriteLine($"{result}");
            #endregion
        }
    }
}
