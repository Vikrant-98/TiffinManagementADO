using Repository.Interface;
using System.Data;
using System.Data.SqlClient;
using TiffinManagement.DatabaseServices;
using TiffinManagement.MapperServices;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace Repository.Services
{
    public class TiffinServices : ITiffinServices
    {
        private readonly DBService _dBService;
        private readonly DatabaseMapper _databaseMapper;
        public TiffinServices(DBService dBService, DatabaseMapper databaseMapper)
        {
            _dBService = dBService;
            _databaseMapper = databaseMapper;
        }

        public async Task<List<TiffinDetails>> GetAllTiffin()
        {
            SqlDataReader dataReader;
            List<TiffinDetails>? TiffinList = new List<TiffinDetails>();
            try
            {
                using (SqlCommand command = new SqlCommand("spGetTiffinDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    _dBService.Connection.Open();
                    dataReader = await command.ExecuteReaderAsync();
                    TiffinList = _databaseMapper.GetAllTiffin(dataReader);
                    _dBService.Connection.Close();

                };

                return TiffinList;
            }
            catch (Exception)
            {
                throw;
            }

        }
         
        public async Task<AddResponse> AddTiffin(AddTiffin addTiffin, int Id) 
        {
            SqlDataReader dataReader;
            AddResponse? response = new AddResponse();
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
        
        public async Task<AddResponse> EditTiffin(AddTiffinModifier addTiffin, string ImageUrl)
        {
            SqlDataReader dataReader;
            AddResponse? response = new AddResponse();
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

        public async Task<AddResponse> DeleteTiffin(int id)
        {
            SqlDataReader dataReader;
            AddResponse? response = new AddResponse();
            try
            {
                using (SqlCommand command = new SqlCommand("spDeleteTiffinDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TiffinId", id);

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

