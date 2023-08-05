using TiffinManagement.Business.Interface;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;
using TiffinManagement.Repository.Interface;

namespace TiffinManagement.Business.Services
{
    public class OrderBusiness : IOrderBusiness
    {
        readonly private IOrderServices _orderServices;
        public OrderBusiness(IOrderServices orderServices) 
        {
            _orderServices = orderServices;
        }

        public async Task<List<OrdersDetails>> GetAllOrders() 
        {
            List<OrdersDetails>? OrderDetails = new List<OrdersDetails>();
            try
            {
                 OrderDetails = await _orderServices.GetAllOrders().ConfigureAwait(false);
                              
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
        
        public async Task<AddResponse> AddOrdersByUserId(int UserId, AddOrderDetailsResponse addOrder)
        {
            AddResponse? AddResponse = new AddResponse();
            try
            {
                AddOrderDetails addOrderDetails = new AddOrderDetails()
                {
                    AddressId = addOrder.AddressId,
                    EndDate = DateTime.Parse(addOrder.EndDate),
                    StartDate = DateTime.Parse(addOrder.StartDate),
                    PaymentMode = addOrder.PaymentMode,
                    TiffinId = addOrder.TiffinId,
                };

               return await _orderServices.AddOrdersByUserId(UserId, addOrderDetails).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<AddResponse> UpdateOrderStatus(UpdateOrder updateOrder, int UserId)
        {
            AddResponse? AddResponse = new AddResponse();
            try
            {
                return await _orderServices.UpdateOrdersStatus(updateOrder,UserId).ConfigureAwait(false);                
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
