using Repository.Interface;
using System.Data;
using System.Data.SqlClient;
using TiffinManagement.DatabaseServices;
using TiffinManagement.ModelServices.Request;

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
         
        public async Task<SqlDataReader> AddTiffin(AddTiffin addTiffin, int Id) 
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddTiffinDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", addTiffin.Name);
                    command.Parameters.AddWithValue("@Price", addTiffin.Price);
                    command.Parameters.AddWithValue("@ImageUrl", addTiffin.ImageURL);
                    command.Parameters.AddWithValue("@Description", addTiffin.Description);
                    command.Parameters.AddWithValue("@Address", addTiffin.TiffinAddress);
                    command.Parameters.AddWithValue("@userId", Id);

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
        
        public async Task<SqlDataReader> EditTiffin(AddTiffinModifier addTiffin, string ImageUrl)
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spUpdateTiffinDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", addTiffin.Name);
                    command.Parameters.AddWithValue("@Price", addTiffin.Price);
                    command.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                    command.Parameters.AddWithValue("@Description", addTiffin.Description);
                    command.Parameters.AddWithValue("@TiffinAddress", addTiffin.TiffinAddress);
                    command.Parameters.AddWithValue("@TiffinId", addTiffin.TiffinId);

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
                using (SqlCommand command = new SqlCommand("spDeleteTiffinDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TiffinId", id);

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

