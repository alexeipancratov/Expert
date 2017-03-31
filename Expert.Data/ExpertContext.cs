﻿using System.Configuration;
using MongoDB.Driver;

namespace Expert.Data
{
    public class ExpertContext
    {
        public IMongoDatabase Database;

        public ExpertContext()
        {
            var client = new MongoClient(ConfigurationManager.ConnectionStrings["ExpertConnectionString"].Name);
            Database = client.GetDatabase(ConfigurationManager.AppSettings["ExpertDatabaseName"]);
        }
    }
}