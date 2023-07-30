using System.Data.SqlClient;
using TiffinManagement.Business.Interface;
using TiffinManagement.MapperServices;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;
using TiffinManagement.Repository.Interface;

namespace TiffinManagement.Business.Services
{
    public class OrderBusiness : IOrderBusiness
    {
        readonly private IOrderServices _orderServices;
        private readonly DatabaseMapper _databaseMapper;
        public OrderBusiness(IOrderServices orderServices, DatabaseMapper databaseMapper) 
        {
            _orderServices = orderServices;
            _databaseMapper = databaseMapper;
        }

        public async Task<List<OrdersDetails>> GetAllOrders() 
        {
            List<OrdersDetails>? OrderDetails = new List<OrdersDetails>();
            try
            {
                var Details = await _orderServices.GetAllOrders().ConfigureAwait(false);
                              
            }
            catch (Exception)
            {
                throw;
            }
            return OrderDetails;
        }
        
        public async Task<List<OrdersDetails>> GetAllOrdersByUserId(int UserId)
        {
            List<OrdersDetails>? OrderDetails = new List<OrdersDetails>();
            try
            {
                return await _orderServices.GetAllOrdersByUserId(UserId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<AddResponse> AddOrdersByUserId(int UserId, AddOrderDetails addOrder)
        {
            AddResponse? AddResponse = new AddResponse();
            try
            {
               return await _orderServices.AddOrdersByUserId(UserId,addOrder).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<AddResponse> UpdateOrderStatus(UpdateOrder updateOrder)
        {
            AddResponse? AddResponse = new AddResponse();
            try
            {
                return await _orderServices.UpdateOrdersStatus(updateOrder).ConfigureAwait(false);                
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<AddResponse> DeleteOrdersByUserId(int OrderId,int UserId)
        {
            AddResponse? AddResponse = new AddResponse();
            try
            {
                return await _orderServices.DeleteOrdersByUserId(OrderId, UserId).ConfigureAwait(false);                
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
