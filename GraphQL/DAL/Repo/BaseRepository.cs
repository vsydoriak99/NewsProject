using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewsProject.DAL.Database;
using NewsProject.DAL.DTO;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace NewsProject.DAL.Repo
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseDTO
    {
        protected readonly IMongoDBContext _mongoContext;
        protected IMongoCollection<TEntity> _dbCollection;

        protected BaseRepository(IMongoDBContext context)
        {
            _mongoContext = context;
           
        }


        public TEntity Get(string id)
        {
            //ex. 5dc1039a1521eaa36835e541

            var objectId = new ObjectId(id);

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

            return _dbCollection.Find(filter).FirstOrDefault();

        }
        

        public IEnumerable<TEntity> Get()
        {
            var all = _dbCollection.Find(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }
        public virtual void Create(TEntity obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            _dbCollection.InsertOne(obj);
        }

        public virtual void Update(TEntity obj)
        {
            var objectId = new ObjectId(obj.Id);

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            _dbCollection.ReplaceOne(filter, obj);
        }
        public void Delete(string id)
        {
            var objectId = new ObjectId(id);
            _dbCollection.DeleteOne(Builders<TEntity>.Filter.Eq("_id", objectId));

        }

    }
}
