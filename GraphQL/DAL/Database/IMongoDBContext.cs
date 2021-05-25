using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsProject.DAL.Database
{
    public interface IMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
