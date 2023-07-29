using TiffinManagement.Business.Interface;
using TiffinManagement.MapperServices;
using TiffinManagement.ModelServices.Response;
using TiffinManagement.Repository.Interface;
using TiffinManagement.Repository.Services;

namespace TiffinManagement.Business.Services
{
    public class DeliveryBusiness : IDeliveryBusiness
    {
        readonly private IDeliveryServices _deliveryServices;
        private readonly DatabaseMapper _databaseMapper;

        public DeliveryBusiness(IDeliveryServices deliveryServices, DatabaseMapper databaseMapper)
        {
            _deliveryServices = deliveryServices;
            _databaseMapper = databaseMapper;
        }

        public async Task<List<OrdersDetails>> GetAllOrders()
        {
            List<OrdersDetails>? OrderDetails = new List<OrdersDetails>();
            try
            {
                var Details = await _deliveryServices.GetAllDeliveryDetails().ConfigureAwait(false);
                OrderDetails = _databaseMapper.GetAllOrders(Details);
            }
            catch (Exception)
            {
                throw;
            }
            return OrderDetails;
        }

    }
}
