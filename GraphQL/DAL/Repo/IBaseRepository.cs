using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsProject.DAL.Repo
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(string id);
        TEntity Get(string id);
        IEnumerable<TEntity> Get();
    }
}
