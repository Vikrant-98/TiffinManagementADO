using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiffinManagement.Business.Interface;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderBusiness _orderBusiness;

        OrderController(IOrderBusiness orderBusiness) 
        {
            _orderBusiness = orderBusiness;
        }

        [HttpGet("GetAllOrders")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<List<OrdersDetails>> GetAllTiffin()
        {
            List<OrdersDetails> ordersDetails = new List<OrdersDetails>();
            try
            {
                ordersDetails = await _orderBusiness.GetAllOrders().ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }

            return ordersDetails;
        }

        [HttpGet("GetAllOrdersByUserId")]
        [Authorize(Roles = "Customer,Delivery")]
        public async Task<List<OrdersDetails>> GetAllOrdersByUserId()
        {
            List<OrdersDetails> ordersDetails = new List<OrdersDetails>();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserId").Value);
                ordersDetails = await _orderBusiness.GetAllOrdersByUserId(userId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }

            return ordersDetails;
        }

        [HttpPost("UpdateOrderStatus")]
        [Authorize(Roles = "Delivery")]
        public async Task<AddResponse> UpdateOrderStatus([FromBody] UpdateOrder updateOrder)
        {
            AddResponse ordersDetails = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserId").Value);
                ordersDetails = await _orderBusiness.UpdateOrderStatus(updateOrder).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }

            return ordersDetails;
        }

        [HttpPost("AddOrdersByUserId")]
        [Authorize(Roles = "Customer")]
        public async Task<AddResponse> UpdateOrderStatus([FromBody] AddOrderDetails addOrder)
        {
            AddResponse ordersDetails = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserId").Value);
                ordersDetails = await _orderBusiness.AddOrdersByUserId(userId, addOrder).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            return ordersDetails;
        }

        [HttpDelete("{OrderId}")]
        [Authorize(Roles = "Customer")]
        public async Task<AddResponse> DeleteOrdersByUserId(int OrderId)
        {
            AddResponse ordersDetails = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserId").Value);
                ordersDetails = await _orderBusiness.DeleteOrdersByUserId(OrderId, userId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            return ordersDetails;
        }

    }
}
