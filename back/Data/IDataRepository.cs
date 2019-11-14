using System.Collections.Generic;
using back.Models;

namespace back.Data
{
    public interface IDataRepository<TEntity>
    {
        void Create(TEntity seguro);
        Seguro Read(int Id);
        void Update(int Id, TEntity seguro);
        void Delete(int Id);
        List<TEntity> GetList();

    }
}