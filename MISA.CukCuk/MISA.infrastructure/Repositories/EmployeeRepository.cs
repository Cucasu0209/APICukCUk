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
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion


        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnection");
            _dbConnection = new MySqlConnection(_connectionString);
        }

        public override int Add(Employee employee)
        {
            try
            {
                var sqlCommand = $"INSERT INTO Employee " +
                     $"(EmployeeId,EmployeeCode,FullName,Gender,DateOfBirth,PhoneNumber,Email,Address,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy)" +
                     " VALUES " +
                     $"(@EmployeeId,@EmployeeCode,@FullName,@Gender,@DateOfBirth,@PhoneNumber,@Email,@Address,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                DynamicParameters parameters = new DynamicParameters();
                var newID = (Guid.NewGuid()).ToString();
                parameters.Add($"@EmployeeId", newID);
                parameters.Add($"@EmployeeCode", employee.EmployeeCode);
                parameters.Add($"@FullName", employee.FullName);
                parameters.Add($"@Gender", employee.Gender);
                parameters.Add($"@DateOfBirth", employee.DateOfBirth);
                parameters.Add($"@PhoneNumber", employee.PhoneNumber);
                parameters.Add($"@Email", employee.Email);
                parameters.Add($"@Address", employee.Address);

                parameters.Add($"@CreatedDate", DateTime.Now);
                parameters.Add($"@CreatedBy", "Hehe");
                parameters.Add($"@ModifiedDate", DateTime.Now);
                parameters.Add($"@ModifiedBy", "Hehe");

                var rowAffect = _dbConnection.Execute(sqlCommand, parameters);

                return rowAffect;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public override int Update(Guid id, Employee employee)
        {
            try
            {
                var sqlCommand = $"UPDATE Employee " +
                    $"SET " +
                    $"EmployeeCode=@EmployeeCode," +
                    $"FullName=@FullName," +
                    $"Gender=@Gender," +
                    $"DateOfBirth=@DateOfBirth," +
                    $"PhoneNumber=@PhoneNumber," +
                    $"Email=@Email," +
                    $"DateOfBirth=@DateOfBirth," +
                    $"Address=@Address," +
                    $"ModifiedDate=@ModifiedDate," +
                    $"ModifiedBy=@ModifiedBy" +
                    $" WHERE EmployeeId = @id";


                DynamicParameters parameters = new DynamicParameters();
                var newID = (Guid.NewGuid()).ToString();
                parameters.Add($"@id", id.ToString());
                parameters.Add($"@EmployeeCode", employee.EmployeeCode);
                parameters.Add($"@FullName", employee.FullName);
                parameters.Add($"@Gender", employee.Gender);
                parameters.Add($"@DateOfBirth", employee.DateOfBirth);
                parameters.Add($"@PhoneNumber", employee.PhoneNumber);
                parameters.Add($"@Email", employee.Email);
                parameters.Add($"@Address", employee.Address);

                parameters.Add($"@ModifiedDate", DateTime.Now);
                parameters.Add($"@ModifiedBy", "Hehe");

                var rowAffect = _dbConnection.Execute(sqlCommand, parameters);

                return rowAffect;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
