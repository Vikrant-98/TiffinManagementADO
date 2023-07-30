using System.Data.SqlClient;
using System.Data;
using TiffinManagement.DatabaseServices;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.Repository.Interface;

namespace TiffinManagement.Repository.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly DBService _dBService;
        public OrderServices(DBService dBService)
        {
            _dBService = dBService;
        }

        public async Task<SqlDataReader> GetAllOrders()
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spGetTiffinDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    _dBService.Connection.Close();

                };

                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<SqlDataReader> GetAllOrdersByUserId(int UserId)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spGetOrderDetailsByUserId", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", UserId);
                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    _dBService.Connection.Close();

                };

                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<SqlDataReader> AddOrdersByUserId(int UserId, AddOrderDetails addOrder) 
        {
            SqlDataReader dataReader;
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
                    _dBService.Connection.Close();

                };

                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<SqlDataReader> UpdateOrdersStatus(UpdateOrder updateOrder)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddOrderDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", updateOrder.OrderId);
                    command.Parameters.AddWithValue("@DeliveryHolderId", updateOrder.DeliveryHolderId);
                    command.Parameters.AddWithValue("@Status", updateOrder.Status);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    _dBService.Connection.Close();

                };

                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public async Task<SqlDataReader> DeleteOrdersByUserId(int OrderId,int UserId)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spDeleteOrderDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", OrderId);
                    command.Parameters.AddWithValue("@UserID", UserId);

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    _dBService.Connection.Close();

                };

                return dataReader;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
