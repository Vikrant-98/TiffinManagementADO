using System.Data.SqlClient;
using TiffinManagement.Business.Interface;
using TiffinManagement.MapperServices;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;
using TiffinManagement.Repository.Interface;

namespace TiffinManagement.Business.Services
{
    public class UserBusiness : IUserBusiness
    {
        private readonly DatabaseMapper _databaseMapper;
        private readonly IUserService _userServices;
        public UserBusiness(DatabaseMapper databaseMapper, IUserService userServices) 
        {
            _databaseMapper = databaseMapper;
            _userServices = userServices;
        }

        public async Task<List<Login>> GetUserActiveDetails()
        {
            try
            {
                SqlDataReader? dataReader = await _userServices.GetUserActiveDetails().ConfigureAwait(false);
                List<Login>? response = _databaseMapper.ActiveUserResponse(dataReader);
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<Login> UserLogin(UserLogin User)
        {
            try
            {
                SqlDataReader? dataReader = await _userServices.UserLogin(User).ConfigureAwait(false);
                Login? response = _databaseMapper.LoginResponse(dataReader);
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> AddUser(UserRegistration User)
        {
            try
            {
                SqlDataReader? dataReader = await _userServices.AddUser(User).ConfigureAwait(false);
                AddResponse? response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> AddUserAddress(UserAddress UserAddress,int UserId)
        {
            try
            {
                SqlDataReader? dataReader = await _userServices.AddUserAddress(UserAddress, UserId).ConfigureAwait(false);
                AddResponse? response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> AddAddress(TiffinAddress TiffinAddress, int UserId)
        {
            try
            {
                SqlDataReader? dataReader = await _userServices.AddAddress(TiffinAddress, UserId).ConfigureAwait(false);
                AddResponse? response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> UpdateUser(UserRegistration TiffinAddress, int UserId)
        {
            try
            {
                UpdateUser updateUser = new UpdateUser() 
                {
                    Id = UserId,
                    EmailID = TiffinAddress.EmailID,
                    AadharNumber = TiffinAddress.AadharNumber,
                    FirstName = TiffinAddress.FirstName,
                    LastName = TiffinAddress.LastName,
                    Password = TiffinAddress.Password,
                    Role = TiffinAddress.Role
                };
                SqlDataReader? dataReader = await _userServices.UpdateUser(updateUser).ConfigureAwait(false);
                AddResponse? response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<Login>> GetRoleBaseDetails(string Role) 
        {
            List<Login>? response = new List<Login>();
            try
            {
                SqlDataReader? dataReader = await _userServices.GetRoleBaseDetails(Role).ConfigureAwait(false);
                response = _databaseMapper.MapGetRoleBaseDetails(dataReader);
            }
            catch (Exception)
            {
                throw;
            }
            
            return response;
        }

    }
}
