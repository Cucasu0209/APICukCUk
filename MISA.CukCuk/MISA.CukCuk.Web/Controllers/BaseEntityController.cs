using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Consts;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;
        public BaseEntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var servieResult = _baseService.GetEntities();
                return StatusCode(servieResult.resultCode, servieResult.data);
            }
            catch (Exception)
            {
                return StatusCode(ResultCode.NOT_FOUND, ResultMessage.NOT_FOUND);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var servieResult = _baseService.GetEntityById(Guid.Parse(id));
                return StatusCode(servieResult.resultCode, servieResult.data);
            }
            catch (Exception)
            {
                return StatusCode(ResultCode.NOT_FOUND, ResultMessage.NOT_FOUND);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            try
            {
                var servieResult = _baseService.Add(entity);
                return StatusCode(servieResult.resultCode, servieResult.data);
            }
            catch (Exception)
            {
                return StatusCode(ResultCode.NOT_FOUND, ResultMessage.NOT_FOUND);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TEntity entity)
        {
            try
            {
                var servieResult = _baseService.Update(Guid.Parse(id), entity);
                return StatusCode(servieResult.resultCode, servieResult.data);
            }
            catch (Exception)
            {
                return StatusCode(ResultCode.NOT_FOUND, ResultMessage.NOT_FOUND);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var servieResult = _baseService.Delete(Guid.Parse(id));
                return StatusCode(servieResult.resultCode, servieResult.data);
            }
            catch (Exception)
            {
                return StatusCode(ResultCode.NOT_FOUND, ResultMessage.NOT_FOUND);
            }
        }
    }
}
