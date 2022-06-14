using Cinema.Configuration;
using Cinema.Data.IRepositories;
using Cinema.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private long lastId;
        readonly string path;
        public MovieRepository()
        {
            dynamic appSettings = ReadFromAppSettings();

            lastId = appSettings.Databases.Movies.LastId;
            path = appSettings.Databases.Movies.Path;
        }
        public Movie Create(Movie movie)
        {
            var movies = GetAll();

            movie.Id = ++lastId;

            movie.CreatedAt = DateTime.Now;

            string json = JsonConvert.SerializeObject(movies.Append(movie), Formatting.Indented);
            File.WriteAllText(path, json);

            SaveToAppSettings();

            return movie;
        }

        public bool Delete(long id)
        {
            var movies = GetAll().Select(p => p.Id != id);

            File.WriteAllText(path, JsonConvert.SerializeObject(movies));

            return true;
        }

        public Movie Get(long id)
            => GetAll().FirstOrDefault(x => x.Id == id);

        public IEnumerable<Movie> GetAll()
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "[]");

            string json = File.ReadAllText(path);

            if (string.IsNullOrEmpty(json))
            {
                File.WriteAllText(path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<IEnumerable<Movie>>(json);
        }

        public Movie Update(Movie movie)
        {
            var movies = GetAll().Select(p => p.Id.Equals(movie.Id) ? movie : p);

            movie.UpdatedAt = DateTime.Now;

            File.WriteAllText(path, JsonConvert.SerializeObject(movies));

            return movie;
        }

        private dynamic ReadFromAppSettings()
        {
            string json = File.ReadAllText(Constants.APP_SETTINGS_PATH);
            return JsonConvert.DeserializeObject<dynamic>(json);
        }

        private void SaveToAppSettings()
        {
            var appSettings = ReadFromAppSettings();
            appSettings.Databases.Movies.LastId = lastId;

            File.WriteAllText(Constants.APP_SETTINGS_PATH, JsonConvert.SerializeObject(appSettings));
        }
    }
}
