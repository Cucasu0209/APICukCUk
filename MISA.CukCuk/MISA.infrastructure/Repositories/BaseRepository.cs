using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        string _tableName;
        #endregion


        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnection");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }
        #endregion
        public virtual int Add(TEntity entity)
        {
            //var sqlCommand = $"INSERT INTO {_tableName} " +
            //     $"({_tableName}Id,{_tableName}Code,FullName,Gender,DateOfBirth,PhoneNumber,Email,Address,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy)" +
            //     " VALUES " +
            //     $"(@{_tableName}Id,@{_tableName}Code,@FullName,@Gender,@DateOfBirth,@PhoneNumber,@Email,@Address,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
            //DynamicParameters parameters = new DynamicParameters();
            //parameters.Add($"@{_tableName}Id", new Guid());
            //parameters.Add($"@{_tableName}Code", ((BaseEntity)entity).GetCode());


            return 0;
        }

        public virtual int Delete(Guid id)
        {
            try
            {
                var sqlCommand = $"DELETE FROM {_tableName} WHERE {_tableName}Id = @{_tableName}id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{_tableName}Id", id.ToString());
                var rowAffect = _dbConnection.Execute(sqlCommand, parameters);
                return rowAffect;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public virtual IEnumerable<TEntity> GetEntities()
        {
            try
            {
                var sqlCommand = $"SELECT * FROM {_tableName}";
                DynamicParameters parameters = new DynamicParameters();
                var entities = _dbConnection.Query<TEntity>(sqlCommand);
                return entities;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public virtual TEntity GetEntityById(Guid id)
        {

            var sqlCommand = $"SELECT * FROM {_tableName} WHERE {_tableName}Id=@{_tableName}Id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{_tableName}Id", id.ToString());
            var entity = _dbConnection.QueryFirstOrDefault<TEntity>(sql: sqlCommand, param: parameters);
            return entity;

        }

        public virtual int Update(Guid id, TEntity entity)
        {
            return 0;
        }
    }
}
