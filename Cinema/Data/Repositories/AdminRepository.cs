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
    public class AdminRepository : IAdminRepository
    {
        private long lastId;
        readonly string path;
        public AdminRepository()
        {
            dynamic appSettings = ReadFromAppSettings();

            lastId = appSettings.Databases.Admins.LastId;
            path = appSettings.Databases.Admins.Path;
        }
        public Admin Create(Admin admin)
        {
            var admins = GetAll();

            admin.Id = ++lastId;

            admin.CreatedAt = DateTime.Now;

            string json = JsonConvert.SerializeObject(admins.Append(admin), Formatting.Indented);
            File.WriteAllText(path, json);

            SaveToAppSettings();

            return admin;
        }

        public bool Delete(long id)
        {
            var admins = GetAll().Select(p => p.Id != id);

            File.WriteAllText(path, JsonConvert.SerializeObject(admins));

            return true;
        }

        public Admin Get(long id)
            => GetAll().FirstOrDefault(x => x.Id == id);

        public IEnumerable<Admin> GetAll()
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "[]");

            string json = File.ReadAllText(path);

            if (string.IsNullOrEmpty(json))
            {
                File.WriteAllText(path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<IEnumerable<Admin>>(json);
        }

        public Admin Update(Admin admin)
        {
            var admins = GetAll().Select(p => p.Id.Equals(admin.Id) ? admin : p);

            admin.UpdatedAt = DateTime.Now;

            File.WriteAllText(path, JsonConvert.SerializeObject(admins));

            return admin;
        }

        private dynamic ReadFromAppSettings()
        {
            string json = File.ReadAllText(Constants.APP_SETTINGS_PATH);
            return JsonConvert.DeserializeObject<dynamic>(json);
        }

        private void SaveToAppSettings()
        {
            var appSettings = ReadFromAppSettings();
            appSettings.Databases.Admins.LastId = lastId;

            File.WriteAllText(Constants.APP_SETTINGS_PATH, JsonConvert.SerializeObject(appSettings));
        }
    }
}
