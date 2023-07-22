using System.Data;
using System.Data.SqlClient;
using TiffinManagement.DatabaseServices;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.Repository.Interface;

namespace TiffinManagement.Repository.Services
{
    public class UserService : IUserService
    {

        private readonly DBService _dBService;
        public UserService(DBService dBService) 
        {
            _dBService = dBService;
        }

        public async Task<SqlDataReader> AddUserAddress(UserAddress Address)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddDeliveryDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Adderess", Address.Address);
                    command.Parameters.AddWithValue("@Id", Address.id);

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
