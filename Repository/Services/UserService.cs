using System.Data;
using System.Data.SqlClient;
using TiffinManagement.DatabaseServices;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.Repository.Interface;

namespace TiffinManagement.Repository.Services
{
    public class UserService : IUserService
    {

        private readonly DBService _dBService;
        public UserService(DBService dBService) 
        {
            _dBService = dBService;
        }

        public async Task<SqlDataReader> AddUser(UserRegistration User)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddUserDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", User.FirstName);
                    command.Parameters.AddWithValue("@LastName", User.LastName);
                    command.Parameters.AddWithValue("@EmailID", User.Role);
                    command.Parameters.AddWithValue("@EmailID", User.EmailID);
                    command.Parameters.AddWithValue("@Password", User.Password);
                    command.Parameters.AddWithValue("@AadharNumber", User.AadharNumber);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    _dBService.Connection.Close();

                };

                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SqlDataReader> UserLogin(UserLogin User)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spUserLogin", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmailID", User.UserId);
                    command.Parameters.AddWithValue("@Password", User.Password);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    _dBService.Connection.Close();

                };

                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SqlDataReader> UpdateUser(UpdateUser User)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spUpdateUserDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", User.Id);
                    command.Parameters.AddWithValue("@FirstName", User.FirstName);
                    command.Parameters.AddWithValue("@LastName", User.LastName);
                    command.Parameters.AddWithValue("@EmailID", User.EmailID);
                    command.Parameters.AddWithValue("@Password", User.Password);
                    command.Parameters.AddWithValue("@AadharNumber", User.AadharNumber);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    _dBService.Connection.Close();

                };

                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SqlDataReader> AddUserAddress(UserAddress Address)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddDeliveryDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Adderess", Address.Address);
                    command.Parameters.AddWithValue("@Id", Address.id);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    _dBService.Connection.Close();

                };

                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
