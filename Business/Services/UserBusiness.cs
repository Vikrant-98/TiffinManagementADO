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
                return await _userServices.GetUserActiveDetails().ConfigureAwait(false);
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
                return await _userServices.UserLogin(User).ConfigureAwait(false);
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
                return await _userServices.AddUser(User).ConfigureAwait(false);                
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
                return await _userServices.AddUserAddress(UserAddress, UserId).ConfigureAwait(false);
                
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
                return await _userServices.AddAddress(TiffinAddress, UserId).ConfigureAwait(false);
                
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> UpdateUser(User TiffinAddress, int UserId)
        {
            try
            {
                UpdateUser updateUser = new UpdateUser() 
                {
                    Id = UserId,
                    AadharNumber = TiffinAddress.AadharNumber,
                    FirstName = TiffinAddress.FirstName,
                    LastName = TiffinAddress.LastName,
                    Password = TiffinAddress.Password,
                    Role = TiffinAddress.Role
                };
                return await _userServices.UpdateUser(updateUser).ConfigureAwait(false);
                
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
                return await _userServices.GetRoleBaseDetails(Role).ConfigureAwait(false);                
            }
            catch (Exception)
            {
                throw;
            }            
        }

    }
}
