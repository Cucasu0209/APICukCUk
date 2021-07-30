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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        #region declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion


        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnection");
            _dbConnection = new MySqlConnection(_connectionString);
        }

        public override int Add(Customer customer)
        {
            try
            {
                var sqlCommand = $"INSERT INTO Customer " +
                                 $"(CustomerId,CustomerCode,FullName,Gender,DateOfBirth,PhoneNumber,Email,Address,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy)" +
                                 " VALUES " +
                                 $"(@CustomerId,@CustomerCode,@FullName,@Gender,@DateOfBirth,@PhoneNumber,@Email,@Address,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                DynamicParameters parameters = new DynamicParameters();
                var newID = (Guid.NewGuid()).ToString();
                parameters.Add($"@CustomerId", newID);
                parameters.Add($"@CustomerCode", customer.CustomerCode);
                parameters.Add($"@FullName", customer.FullName);
                parameters.Add($"@Gender", customer.Gender);
                parameters.Add($"@DateOfBirth", customer.DateOfBirth);
                parameters.Add($"@PhoneNumber", customer.PhoneNumber);
                parameters.Add($"@Email", customer.Email);
                parameters.Add($"@Address", customer.Address);

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

        public override int Update(Guid id, Customer customer)
        {
            try
            {
                var sqlCommand = $"UPDATE Customer " +
                    $"SET " +
                    $"CustomerCode=@CustomerCode," +
                    $"FullName=@FullName," +
                    $"Gender=@Gender," +
                    $"DateOfBirth=@DateOfBirth," +
                    $"PhoneNumber=@PhoneNumber," +
                    $"Email=@Email," +
                    $"DateOfBirth=@DateOfBirth," +
                    $"Address=@Address," +
                    $"ModifiedDate=@ModifiedDate," +
                    $"ModifiedBy=@ModifiedBy" +
                    $" WHERE CustomerId = @id";


                DynamicParameters parameters = new DynamicParameters();
                var newID = (Guid.NewGuid()).ToString();
                parameters.Add($"@id", id.ToString());
                parameters.Add($"@CustomerCode", customer.CustomerCode);
                parameters.Add($"@FullName", customer.FullName);
                parameters.Add($"@Gender", customer.Gender);
                parameters.Add($"@DateOfBirth", customer.DateOfBirth);
                parameters.Add($"@PhoneNumber", customer.PhoneNumber);
                parameters.Add($"@Email", customer.Email);
                parameters.Add($"@Address", customer.Address);

                parameters.Add($"@ModifiedDate", DateTime.Now);
                parameters.Add($"@ModifiedBy", "Hehe");

                var rowAffect = _dbConnection.Execute(sqlCommand, parameters);

                return rowAffect;
            }catch(Exception e)
            {
                return 0;
            }
        }
    }
}
