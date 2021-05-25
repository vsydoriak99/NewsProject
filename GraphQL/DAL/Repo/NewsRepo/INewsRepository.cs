using System;
using System.Collections.Generic;
using System.Text;
using NewsProject.DAL.DTO;

namespace NewsProject.DAL.Repo.NewsRepo
{
    public interface INewsRepository : IBaseRepository<NewsDTO>
    {
         IEnumerable<NewsDTO> GetNewsByUser(string userId);

        IEnumerable<NewsDTO> GetNotReadsNews(string userId);
        NewsDTO AddLikes(string newsId, string userId);
        NewsDTO RemoveLikes(string newsId, string userId);

        NewsDTO ReadNews(string newsId, string userId);
    }
}
