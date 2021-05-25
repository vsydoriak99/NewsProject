using Microsoft.Extensions.Options;
using NewsProject.DAL.Database;
using NewsProject.DAL.Repo.NewsRepo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace NewsProject.Receiver
{
    public class DBHelper
    {
        private static INewsRepository newsRepository;
        public static INewsRepository GetNewsRepository()
        {
            if (newsRepository == null)
            {
                MongoSettings appSettings = new MongoSettings()
                {
                    ConnectionString = ConfigurationManager.AppSettings.Get("ConnectionString"),
                    DatabaseName = ConfigurationManager.AppSettings.Get("DatabaseName")
                };
                IOptions<MongoSettings> options = Options.Create(appSettings);
                newsRepository = new NewsRepository(new MongoDBContext(options));
            }
            return newsRepository;

        }
    }
}
