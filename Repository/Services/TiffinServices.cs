using Repository.Interface;
using System.Data.SqlClient;
using System.Data;
using TiffinManagement.DatabaseServices;
using TiffinManagement.ModelServices.ProcessModel;

namespace Repository.Services
{
    public class TiffinServices : ITiffinServices
    {
        private readonly DBService _dBService;
        public TiffinServices(DBService dBService)
        {
            _dBService = dBService;
        }

        public async Task<SqlDataReader> GetAllTiffin()
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
         
        public async Task<SqlDataReader> AddTiffin(AddTiffinModifier addTiffin, int Id) 
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddTiffinDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", addTiffin.Name);
                    command.Parameters.AddWithValue("@Price", addTiffin.Price);
                    command.Parameters.AddWithValue("@ImageUrl", addTiffin.ImageUrl);
                    command.Parameters.AddWithValue("@Description", addTiffin.Description);
                    command.Parameters.AddWithValue("@Address", addTiffin.Address);
                    command.Parameters.AddWithValue("@AdminId", Id);

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

        
        public async Task<SqlDataReader> EditTiffin(AddTiffinModifier addTiffin)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spEditTiffinDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", addTiffin.Name);
                    command.Parameters.AddWithValue("@Price", addTiffin.Price);
                    command.Parameters.AddWithValue("@ImageUrl", addTiffin.ImageUrl);
                    command.Parameters.AddWithValue("@Description", addTiffin.Description);
                    command.Parameters.AddWithValue("@Address", addTiffin.Address);

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

        
        public async Task<SqlDataReader> DeleteTiffin(int id)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spDeleteTiffin", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

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

