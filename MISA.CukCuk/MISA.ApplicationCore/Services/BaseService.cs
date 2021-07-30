using MISA.ApplicationCore.Consts;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public ServiceResult Add(TEntity entity)
        {
            ServiceResult result = new ServiceResult();
            var data = _baseRepository.Add(entity);

            if (data >= 1)
            {
                result.data = data;
                result.resultCode = ResultCode.CREATED;
                result.message = ResultMessage.SUCCESS;
            }
            else
            {
                result.data = data;
                result.resultCode = ResultCode.BAD_REQUEST;
                result.message = ResultMessage.FAIL;
            }
            return result;
        }

        public ServiceResult Delete(Guid id)
        {
            ServiceResult result = new ServiceResult();
            var data = _baseRepository.Delete(id);

            if (data >= 1)
            {
                result.data = data;
                result.resultCode = ResultCode.OK;
                result.message = ResultMessage.SUCCESS;
            }
            else
            {
                result.data = data;
                result.resultCode = ResultCode.BAD_REQUEST;
                result.message = ResultMessage.FAIL;
            }
            return result;
        }

        public ServiceResult GetEntities()
        {
            ServiceResult result = new ServiceResult();
            var data = _baseRepository.GetEntities();

            if (data.Count() >= 1)
            {
                result.data = data;
                result.resultCode = ResultCode.OK;
                result.message = ResultMessage.SUCCESS;
            }
            else
            {
                result.data = data;
                result.resultCode = ResultCode.NO_CONTENT;
                result.message = ResultMessage.NO_CONTENT;
            }
            return result;
        }

        public ServiceResult GetEntityById(Guid id)
        {
            ServiceResult result = new ServiceResult();
            var data = _baseRepository.GetEntityById(id);

            if (data != null)
            {
                result.data = data;
                result.resultCode = ResultCode.OK;
                result.message = ResultMessage.SUCCESS;
            }
            else
            {
                result.data = data;
                result.resultCode = ResultCode.BAD_REQUEST;
                result.message = ResultMessage.FAIL;
            }
            return result;
        }

        public ServiceResult Update(Guid id, TEntity entity)
        {
            ServiceResult result = new ServiceResult();
            var data = _baseRepository.Update(id, entity);

            if (data >= 1)
            {
                result.data = data;
                result.resultCode = ResultCode.OK;
                result.message = ResultMessage.SUCCESS;
            }
            else
            {
                result.data = data;
                result.resultCode = ResultCode.BAD_REQUEST;
                result.message = ResultMessage.FAIL;
            }
            return result;
        }
    }
}
