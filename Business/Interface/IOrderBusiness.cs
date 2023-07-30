using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagement.Business.Interface
{
    public interface IOrderBusiness
    {
        Task<List<OrdersDetails>> GetAllOrders();
        Task<List<OrdersDetails>> GetAllOrdersByUserId(int UserId);
        Task<AddResponse> AddOrdersByUserId(int UserId, AddOrderDetails addOrder);
        Task<AddResponse> UpdateOrderStatus(UpdateOrder updateOrder);
        Task<AddResponse> DeleteOrdersByUserId(int OrderId, int UserId);
    }
}
