using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseService<TEntity>
    {
        ServiceResult GetEntities();
        ServiceResult GetEntityById(Guid id);
        ServiceResult Add(TEntity entity);
        ServiceResult Update(Guid id, TEntity entity);
        ServiceResult Delete(Guid id);
    }
}
