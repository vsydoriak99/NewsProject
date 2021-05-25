using System;
using System.Collections.Generic;

namespace NewsProject.Crawler
{
    public interface ICrawl
    {
        public IEnumerable<NewsModel> Crawl(DateTime dateTime);
    }
}
