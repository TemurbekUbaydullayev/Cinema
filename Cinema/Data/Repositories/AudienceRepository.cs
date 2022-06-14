using Cinema.Configuration;
using Cinema.Data.IRepositories;
using Cinema.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cinema.Data.Repositories
{
    public class AudienceRepository : IAudienceRepository
    {
        private long lastId;
        readonly string path;
        public AudienceRepository()
        {
            dynamic appSettings = ReadFromAppSettings();

            lastId = appSettings.Databases.Audiences.LastId;
            path = appSettings.Databases.Audiences.Path;
        }
        public Audience Create(Audience audience)
        {
            var audiences = GetAll();

            audience.Id = ++lastId;

            audience.TimeOfGetTicket = DateTime.Now;

            string json = JsonConvert.SerializeObject(audiences.Append(audience), Formatting.Indented);
            File.WriteAllText(path, json);

            SaveToAppSettings();

            return audience;
        }

        public IEnumerable<Audience> GetAll()
        {
            if (!File.Exists(path))
                File.WriteAllText(path, "[]");

            string json = File.ReadAllText(path);

            if (string.IsNullOrEmpty(json))
            {
                File.WriteAllText(path, "[]");
                json = "[]";
            }

            return JsonConvert.DeserializeObject<IEnumerable<Audience>>(json);
        }

        private dynamic ReadFromAppSettings()
        {
            string json = File.ReadAllText(Constants.APP_SETTINGS_PATH);
            return JsonConvert.DeserializeObject<dynamic>(json);
        }

        private void SaveToAppSettings()
        {
            var appSettings = ReadFromAppSettings();
            appSettings.Databases.Audiences.LastId = lastId;

            File.WriteAllText(Constants.APP_SETTINGS_PATH, JsonConvert.SerializeObject(appSettings));
        }
    }
}
