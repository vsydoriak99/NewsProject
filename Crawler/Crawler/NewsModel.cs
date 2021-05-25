using System;
using System.Collections.Generic;

namespace NewsProject.Crawler
{
    public class NewsModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime DateOfPublication { get; set; }
        public List<string> Keywords { get; set; }

    }
}
