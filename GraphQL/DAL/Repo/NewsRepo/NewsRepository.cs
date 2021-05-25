using NewsProject.DAL.Database;
using NewsProject.DAL.DTO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsProject.DAL.Repo.NewsRepo
{
    public class NewsRepository : BaseRepository<NewsDTO>, INewsRepository
    {
        public NewsRepository(IMongoDBContext context) : base(context)
        {
            _dbCollection = _mongoContext.GetCollection<NewsDTO>("News");
        }
        public IEnumerable<NewsDTO> GetNewsByUser(string userId)
        {
            FilterDefinition<NewsDTO> filter = Builders<NewsDTO>.Filter.Eq("Likes", userId);
            return _dbCollection.Find(filter).ToList();
        }
        public NewsDTO AddLikes(string newsId, string userId)
        {
            var news = Get(newsId);
            if (news != null)
            {
                if (news.Likes == null)
                    news.Likes = new List<string>();
                if (!news.Likes.Contains(userId))
                    news.Likes.Add(userId);
                Update(news);
                return Get(newsId);
            }
            return null;
        }

        public NewsDTO RemoveLikes(string newsId, string userId)
        {
            var news = Get(newsId);
            if (news != null)
            {
                if (news.Likes == null)
                    news.Likes = new List<string>();
                if (news.Likes.Contains(userId))
                    news.Likes.Remove(userId);
                Update(news);
                return Get(newsId);
            }
            return null;
        }
        public IEnumerable<NewsDTO> GetNotReadsNews(string userId)
        {
            FilterDefinition<NewsDTO> filter = Builders<NewsDTO>.Filter.Ne("Readers", userId);
            return _dbCollection.Find(filter).ToList();
        }
        public NewsDTO ReadNews(string newsId, string userId)
        {
            var news = Get(newsId);
            if (news != null)
            {
                if (news.Readers == null)
                    news.Readers = new List<string>();
                if (!news.Readers.Contains(userId))
                    news.Readers.Add(userId);
                Update(news);
                return Get(newsId);
            }
            return null;
        }

        public override void Create(NewsDTO newsDTO)
        {
            FilterDefinition<NewsDTO> filter = Builders<NewsDTO>.Filter.Eq("Title", newsDTO.Title) ;
            if (_dbCollection.Find(filter).Any())
                base.Create(newsDTO);
        }

    }
}
