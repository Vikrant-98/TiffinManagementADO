using System.Data.SqlClient;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagement.MapperServices
{
    public class DatabaseMapper
    {
        public List<TiffinDetails> GetAllOrders(SqlDataReader dataReader) 
        {
            List<TiffinDetails> bookList = new List<TiffinDetails>();
            TiffinDetails responseData = null;
            while (dataReader.Read())
            {
                responseData = new TiffinDetails
                {
                    Id = Convert.ToInt32(dataReader["ID"]),
                    Name = dataReader["Name"].ToString(),
                    Description = dataReader["Description"].ToString(),
                    Price = Convert.ToInt32(dataReader["Price"]),
                    Image = dataReader["Images"].ToString()
                };
                bookList.Add(responseData);
            }
            return bookList;
        }

        public AddResponse AddUpdateDeleteResponse(SqlDataReader dataReader) 
        {
            AddResponse addResponse = null;
            while (dataReader.Read())
            {
                addResponse  = new AddResponse()
                {
                    Message = dataReader["Message"].ToString(),
                };
            }
            return addResponse;
        }


    }
}
