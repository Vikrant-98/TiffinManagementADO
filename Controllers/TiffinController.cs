using Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiffinManagement.Business.Interface;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagementAPI.Controllers
{
    public class TiffinController : Controller
    {
        private readonly ITiffinBusiness _TiffinBusiness;
        private readonly IOrderBusiness _orderBusiness;

        public TiffinController(ITiffinBusiness TiffinBusiness, IOrderBusiness orderBusiness) 
        {
            _TiffinBusiness = TiffinBusiness;
            _orderBusiness = orderBusiness;
        }

        [HttpGet("GetAllTiffin")]
        [Authorize(Roles = "Admin")]
        public async Task<List<TiffinDetails>> GetAllTiffin()
        {
            List<TiffinDetails> tiffinDetails = new List<TiffinDetails>();
            try 
            {
                tiffinDetails = await _TiffinBusiness.GetAllTiffin().ConfigureAwait(false);
            }
            catch (Exception)
            {

                throw;
            }
            
            return tiffinDetails;
        }

        [HttpPost("AddTiffin")]
        [Authorize(Roles = "Admin")]
        public async Task<AddResponse> AddTiffin(AddTiffinRequest addTiffin, IFormFile Image)
        {
            AddResponse? Response = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);
                Response = await _TiffinBusiness.AddTiffin(addTiffin, userId, Image).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }            
            return Response;
        }

        [HttpPost("EditTiffin")]
        [Authorize(Roles = "Admin")]
        public async Task<AddResponse> EditTiffin(AddTiffinModifier addTiffin, IFormFile Image)
        {
            AddResponse? Result = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);
                Result = await _TiffinBusiness.EditTiffin(addTiffin, Image).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }            
            return Result;
        }

        [HttpDelete("{TiffinId}")]
        [Authorize(Roles = "Admin")]
        public async Task<AddResponse> DeleteTiffin(int TiffinId)
        {
            AddResponse? Result = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);
                Result = await _TiffinBusiness.DeleteTiffin(TiffinId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            
            return Result;
        }

        [HttpGet("GetAllOrders")]
        [Authorize(Roles = "Admin,Delivery")]
        public async Task<List<OrdersDetails>> GetAllOrders()
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
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);
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
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);
                ordersDetails = await _orderBusiness.UpdateOrderStatus(updateOrder, userId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }

            return ordersDetails;
        }

        [HttpPost("AddOrdersByUserId")]
        [Authorize(Roles = "Customer")]
        public async Task<AddResponse> AddOrder([FromBody] AddOrderDetailsResponse addOrder)
        {
            AddResponse ordersDetails = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);
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
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserID").Value);
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
