using System.Data.SqlClient;
using System.Data;
using TiffinManagement.DatabaseServices;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.Repository.Interface;
using TiffinManagement.MapperServices;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagement.Repository.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly DBService _dBService;
        private readonly DatabaseMapper _databaseMapper;
        public OrderServices(DBService dBService, DatabaseMapper databaseMapper)
        {
            _dBService = dBService;
            _databaseMapper = databaseMapper;
        }

        public async Task<List<OrdersDetails>> GetAllOrders()
        {
            SqlDataReader dataReader;
            List<OrdersDetails>? OrderDetails = new List<OrdersDetails>();
            try
            {
                using (SqlCommand command = new SqlCommand("spGetOrderDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    OrderDetails = _databaseMapper.GetAllOrders(dataReader);
                    _dBService.Connection.Close();

                };

                return OrderDetails;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<List<OrdersDetails>> GetAllOrdersByUserId(int UserId)
        {
            SqlDataReader dataReader;
            List<OrdersDetails>? OrderDetails = new List<OrdersDetails>();
            try
            {
                using (SqlCommand command = new SqlCommand("spGetOrderDetailsByUserId", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", UserId);
                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    OrderDetails = _databaseMapper.GetAllOrders(dataReader);
                    _dBService.Connection.Close();

                };

                return OrderDetails;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> AddOrdersByUserId(int UserId, AddOrderDetails addOrder) 
        {
            SqlDataReader dataReader;
            AddResponse response = new AddResponse();
            try
            {
                using (SqlCommand command = new SqlCommand("spAddOrderDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@AddressId", addOrder.AddressId);
                    command.Parameters.AddWithValue("@PaymentMode", addOrder.PaymentMode);
                    command.Parameters.AddWithValue("@TiffinId", addOrder.TiffinId);
                    command.Parameters.AddWithValue("@StartDate", addOrder.StartDate);
                    command.Parameters.AddWithValue("@EndDate", addOrder.EndDate);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                    _dBService.Connection.Close();

                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> UpdateOrdersStatus(UpdateOrder updateOrder,int UserId)
        {
            SqlDataReader dataReader;
            AddResponse response = new AddResponse();
            try
            {
                using (SqlCommand command = new SqlCommand("spUpdateOrderDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", updateOrder.OrderId);
                    command.Parameters.AddWithValue("@DeliveryHolderId", UserId);
                    command.Parameters.AddWithValue("@Status", updateOrder.Status);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                    _dBService.Connection.Close();

                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<AddResponse> DeleteOrdersByUserId(int OrderId,int UserId)
        {
            SqlDataReader dataReader;
            AddResponse response = new AddResponse();
            try
            {
                using (SqlCommand command = new SqlCommand("spDeleteOrderDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", OrderId);
                    command.Parameters.AddWithValue("@UserID", UserId);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    response = _databaseMapper.AddUpdateDeleteResponse(dataReader);
                    _dBService.Connection.Close();

                };

                return response;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
