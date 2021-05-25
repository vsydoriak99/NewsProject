using NewsProject.DAL.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsProject.DAL.DTO
{
    public class NewsDTO: BaseDTO
    {
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
        public string Author { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime? DateOfPublication { get; set; } = DateTime.Today;
        public List<string> Likes { get; set; } = new List<string>();
        public List<string> Keywords { get; set; }  = new List<string>(); 

        public List<string> Readers { get; set; } = new List<string>();

    }

}
