using System.Data.SqlClient;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagement.Repository.Interface
{
    public interface IUserService
    {
        Task<AddResponse> AddUserAddress(UserAddress Address, int UserId);
        Task<AddResponse> UpdateUser(UpdateUser User);
        Task<Login> UserLogin(UserLogin User);
        Task<AddResponse> AddUser(UserRegistration User);
        Task<AddResponse> AddAddress(TiffinAddress Address, int UserId);
        Task<List<Login>> GetUserActiveDetails();
        Task<List<Login>> GetRoleBaseDetails(string Role);        
    }
}
