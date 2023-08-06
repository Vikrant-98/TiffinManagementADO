using System.Data;
using System.Data.SqlClient;
using TiffinManagement.DatabaseServices;
using TiffinManagement.MapperServices;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;
using TiffinManagement.Repository.Interface;

namespace TiffinManagement.Repository.Services
{
    public class UserService : IUserService
    {

        private readonly DBService _dBService;
        private readonly DatabaseMapper _databaseMapper;
        public UserService(DBService dBService, DatabaseMapper databaseMapper) 
        {
            _databaseMapper = databaseMapper;
            _dBService = dBService;
        }
        
        public async Task<AddResponse> AddUser(UserRegistration User)
        {
            SqlDataReader dataReader;
            AddResponse? response = new AddResponse();
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
                    response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                    _dBService.Connection.Close();

                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Login>> GetUserActiveDetails()
        {
            SqlDataReader dataReader;
            List<Login>? response = new List<Login>();
            try
            {
                using (SqlCommand command = new SqlCommand("spGetActiveUserDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    response = _databaseMapper.ActiveUserResponse(dataReader);
                    _dBService.Connection.Close();
                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }        
        public async Task<Login> UserLogin(UserLogin User)
        {
            SqlDataReader dataReader;
            Login? response = new Login();
            try
            {
                using (SqlCommand command = new SqlCommand("spUserLogin", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmailID", User.UserId);
                    command.Parameters.AddWithValue("@Password", User.Password);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    response = _databaseMapper.LoginResponse(dataReader);
                    _dBService.Connection.Close();

                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }        
        public async Task<AddResponse> UpdateUser(UpdateUser User)
        {
            SqlDataReader dataReader;
            AddResponse? response = new AddResponse();
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
                    response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                    _dBService.Connection.Close();

                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<AddResponse> AddUserAddress(UserAddress Address,int UserId)
        {
            SqlDataReader dataReader;
            AddResponse? response = new AddResponse();
            try
            {
                using (SqlCommand command = new SqlCommand("spAddUserAddress", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Address", Address.Address);
                    command.Parameters.AddWithValue("@AreaId", Address.AreaId);
                    command.Parameters.AddWithValue("@UserId", UserId);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                   response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                    _dBService.Connection.Close();

                };

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<AddResponse> AddAddress(TiffinAddress Address, int UserId)
        {
            SqlDataReader dataReader;
            AddResponse? response = new AddResponse();
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
                    response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                    _dBService.Connection.Close();

                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Login>> GetRoleBaseDetails(string Role)
        {
            SqlDataReader dataReader;
            List<Login>? response = new List<Login>();
            try
            {
                using (SqlCommand command = new SqlCommand("spGetRoleDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Role", Role);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    response = _databaseMapper.MapGetRoleBaseDetails(dataReader);
                    _dBService.Connection.Close();

                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
