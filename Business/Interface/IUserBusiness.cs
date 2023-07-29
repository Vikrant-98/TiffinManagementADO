using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagement.Business.Interface
{
    public interface IUserBusiness
    {
        Task<List<LoginResponse>> GetUserActiveDetails();
        Task<LoginResponse> UserLogin(UserLogin User);
        Task<AddResponse> AddUser(UserRegistration User);
        Task<AddResponse> AddUserAddress(UserAddress UserAddress, int UserId);
        Task<AddResponse> AddAddress(TiffinAddress TiffinAddress, int UserId);
        Task<AddResponse> UpdateUser(UserRegistration TiffinAddress, int UserId);
        Task<List<LoginResponse>> GetRoleBaseDetails(string Role);
    }
}
