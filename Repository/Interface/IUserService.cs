using System.Data.SqlClient;
using TiffinManagement.ModelServices.Request;

namespace TiffinManagement.Repository.Interface
{
    public interface IUserService
    {
        Task<SqlDataReader> AddUserAddress(UserAddress Address, int UserId);
        Task<SqlDataReader> UpdateUser(UpdateUser User);
        Task<SqlDataReader> UserLogin(UserLogin User);
        Task<SqlDataReader> AddUser(UserRegistration User);
        Task<SqlDataReader> AddAddress(TiffinAddress Address, int UserId);
        Task<SqlDataReader> GetUserActiveDetails();
        Task<SqlDataReader> GetRoleBaseDetails(string Role);
    }
}
