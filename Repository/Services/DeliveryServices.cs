using System.Data;
using System.Data.SqlClient;
using TiffinManagement.DatabaseServices;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.Repository.Interface;

namespace TiffinManagement.Repository.Services
{
    public class DeliveryServices : IDeliveryServices
    {
        private readonly DBService _dBService;
        public DeliveryServices(DBService dBService) 
        {
            _dBService = dBService;
        }

        public async Task<SqlDataReader> AddDeliveryDetails(DeliveryAddress deliveryAddress) 
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddDeliveryDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Adderess", deliveryAddress.Address);
                    command.Parameters.AddWithValue("@Area", deliveryAddress.Area);
                    command.Parameters.AddWithValue("@Pin", deliveryAddress.Pin);

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
        
        public async Task<SqlDataReader> AddDeliveryHolderDetails(DeliveryHolderDetails deliveryHolder) 
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddDeliveryHolderDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", deliveryHolder.FirstName);
                    command.Parameters.AddWithValue("@LastName", deliveryHolder.LastName);
                    command.Parameters.AddWithValue("@Email", deliveryHolder.Email);
                    command.Parameters.AddWithValue("@Password", deliveryHolder.Password);
                    command.Parameters.AddWithValue("@AadharNumber", deliveryHolder.AadharNumber);

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
        
        public async Task<SqlDataReader> GetDeliveryHolderDetails() 
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spGetDeliveryHolderDetails", _dBService.Connection))
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

        public async Task<SqlDataReader> GetDeliveryDetails() 
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spGetDeliveryDetails", _dBService.Connection))
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

    }
}
