using System;
using NewsProject.DAL.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NewsProject.DAL.DTO
{
    public class UserDTO:BaseDTO
    {
        public string Name { get; set; }
    }
}
