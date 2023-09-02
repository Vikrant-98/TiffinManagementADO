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
                var result = await _orderServices.GetAllOrders().ConfigureAwait(false);
                foreach (var item in result.GroupBy(x => x.TiffinId))
                {
                    var tempItem = item.LastOrDefault();
                    tempItem.TotalDays = (tempItem.EndDate - tempItem.StartDate).TotalDays + 1;
                    OrderDetails.Add(tempItem);
                }
                return OrderDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<List<OrdersDetails>> GetAllOrdersByUserId(int UserId)
        {
            List<OrdersDetails>? OrderDetails = new List<OrdersDetails>();
            try
            {
                List<OrdersDetails>? outputResult = new List<OrdersDetails>();
                List<OrdersDetails>? result = await _orderServices.GetAllOrdersByUserId(UserId).ConfigureAwait(false);
                foreach (var item in result.GroupBy(x=>x.TiffinId))
                {
                    var tempItem = item.LastOrDefault();
                    tempItem.TotalDays = (tempItem.EndDate - tempItem.StartDate).TotalDays + 1;
                    outputResult.Add(tempItem);
                }
                return outputResult;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<List<UserAddressResponse>> GetAllAddressByUserId(int UserId)
        {
            List<UserAddressResponse>? OrderDetails = new List<UserAddressResponse>();
            try
            {
                List<UserAddressResponse>? listArea = await _orderServices.GetAllAddressByUserId(UserId).ConfigureAwait(false);
               
                return listArea;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<List<AddressResponse>> GetAllAddress()
        {
            List<AddressResponse>? OrderDetails = new List<AddressResponse>();
            try
            {
                return await _orderServices.GetAllAddress().ConfigureAwait(false);
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
