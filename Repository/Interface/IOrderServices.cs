using System.Data.SqlClient;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagement.Repository.Interface
{
    public interface IOrderServices
    {
        Task<List<OrdersDetails>> GetAllOrders();
        Task<List<OrdersDetails>> GetAllOrdersByUserId(int UserId);
        Task<AddResponse> AddOrdersByUserId(int UserId, AddOrderDetails addOrder);
        Task<AddResponse> UpdateOrdersStatus(UpdateOrder updateOrder);
        Task<AddResponse> DeleteOrdersByUserId(int OrderId, int UserId);
    }
}
