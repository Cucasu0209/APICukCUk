using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> GetEntities();
        TEntity GetEntityById(Guid id);
        int Add(TEntity entity);
        int Update(Guid id, TEntity entity);
        int Delete(Guid id);
    }
}
