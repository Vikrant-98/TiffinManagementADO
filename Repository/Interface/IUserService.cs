using System.Data.SqlClient;
using TiffinManagement.ModelServices.Request;

namespace TiffinManagement.Repository.Interface
{
    public interface IUserService
    {
        Task<SqlDataReader> AddUserAddress(UserAddress Address);
        Task<SqlDataReader> AddUser(UserRegistration User); 
        Task<SqlDataReader> UpdateUser(UpdateUser User);
        Task<SqlDataReader> UserLogin(UserLogin User);
    }
}
