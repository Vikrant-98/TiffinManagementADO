using System.Data.SqlClient;
using TiffinManagement.ModelServices.Request;

namespace TiffinManagement.Repository.Interface
{
    public interface IOrderServices
    {
        Task<SqlDataReader> GetAllOrders();
        Task<SqlDataReader> GetAllOrdersByUserId(int UserId);
        Task<SqlDataReader> AddOrdersByUserId(int UserId, AddOrderDetails addOrder);
        Task<SqlDataReader> UpdateOrdersStatus(UpdateOrder updateOrder);
        Task<SqlDataReader> DeleteOrdersByUserId(int OrderId);
    }
}
