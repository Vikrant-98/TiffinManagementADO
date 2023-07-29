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
                using (SqlCommand command = new SqlCommand("spAddUserDetail", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", User.FirstName);
                    command.Parameters.AddWithValue("@LastName", User.LastName);
                    command.Parameters.AddWithValue("@Role", User.Role);
                    command.Parameters.AddWithValue("@EmailId", User.EmailID);
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
        public async Task<SqlDataReader> GetUserActiveDetails()
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spGetActiveUserDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
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
        public async Task<SqlDataReader> AddUserAddress(UserAddress Address,int UserId)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddUserAddress", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Adderess", Address.Address);
                    command.Parameters.AddWithValue("@AreaId", Address.AreaId);
                    command.Parameters.AddWithValue("@UserId", UserId);

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
        public async Task<SqlDataReader> AddAddress(TiffinAddress Address, int UserId)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddUserAddress", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Adderess", Address.Address);
                    command.Parameters.AddWithValue("@Area", Address.Area);
                    command.Parameters.AddWithValue("@Pin", Address.Pin);
                    command.Parameters.AddWithValue("@UserId", UserId);

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
        public async Task<SqlDataReader> GetRoleBaseDetails(string Role)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spGetRoleDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Role", Role);

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
