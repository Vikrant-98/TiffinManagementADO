using System.Data;
using System.Data.SqlClient;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagement.MapperServices
{
    public class DatabaseMapper
    {
        public List<TiffinDetails> GetAllTiffin(SqlDataReader dataReader) 
        {
            try
            {
                List<TiffinDetails> bookList = new List<TiffinDetails>();
                while (dataReader.Read())
                {
                    bookList.Add(new TiffinDetails
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Rating = dataReader.IsDBNull("Rating") ? 0 : Convert.ToInt32(dataReader["Rating"]),
                        Name = dataReader["TiffinName"].ToString(),
                        Description = dataReader["TiffinDescription"].ToString(),
                        Price = Convert.ToInt32(dataReader["Price"]),
                        Image = dataReader["ImageURL"].ToString(),
                        Area = dataReader["Area"].ToString(),
                        Review = dataReader.IsDBNull("Review") ? string.Empty : dataReader["Review"].ToString()
                    });
                }
                return bookList;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public AddResponse AddUpdateDeleteResponse(SqlDataReader dataReader) 
        {
            AddResponse addResponse = new AddResponse();
            while (dataReader.Read())
            {
                addResponse  = new AddResponse()
                {
                    Message = dataReader["Message"].ToString(),
                    Status = Convert.ToBoolean( dataReader["Status"])
                };
            }
            return addResponse;
        }

        public List<Login> ActiveUserResponse(SqlDataReader dataReader)
        {
            List<Login> addResponse = new List<Login>();
            while (dataReader.Read())
            {
                addResponse.Add(new Login()
                {
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    AadharNumber = dataReader["AadharNumber"].ToString(),
                    EmailId = dataReader["EmailId"].ToString(),
                    Role = dataReader["Role"].ToString(),
                });
            }
            return addResponse;
        }

        public List<OrdersDetails> GetAllOrders(SqlDataReader dataReader) 
        {
            List<OrdersDetails> ordersDetails = new List<OrdersDetails>();
            while (dataReader.Read())
            {
                ordersDetails.Add(new OrdersDetails()
                {
                    OrderId = Convert.ToInt32(dataReader["Id"]),
                    FirstName = dataReader["FirstName"].ToString(),
                    TiffinName = dataReader["TiffinName"].ToString(),
                    TiffinDescription = dataReader["TiffinDescription"].ToString(),
                    Price = dataReader["Price"].ToString(),
                    ImageURL = dataReader["ImageURL"].ToString(),
                    EndDate = dataReader["EndDate"].ToString(),
                    StartDate = dataReader["StartDate"].ToString(),
                });
            }
            return ordersDetails;
        }

        public List<UserAddressResponse> GetAllUserAddress(SqlDataReader dataReader)
        {
            List<UserAddressResponse> ordersDetails = new List<UserAddressResponse>();
            while (dataReader.Read())
            {
                ordersDetails.Add(new UserAddressResponse()
                {
                    AddressId = Convert.ToInt32(dataReader["AreaId"]),
                    Address = dataReader["Address"].ToString(),
                    UserAddress = dataReader["UserAddress"].ToString(),
                    Area = dataReader["Area"].ToString(),
                    Pin = dataReader["Pin"].ToString()
                });
            }
            return ordersDetails;
        }

        public List<AddressResponse> GetAllAddress(SqlDataReader dataReader)
        {
            List<AddressResponse> ordersDetails = new List<AddressResponse>();
            while (dataReader.Read())
            {
                ordersDetails.Add(new AddressResponse()
                {
                    AddressId = Convert.ToInt32(dataReader["Id"]),
                    Address = dataReader["Address"].ToString(),
                    Area = dataReader["Area"].ToString(),
                    Pin = dataReader["Pin"].ToString()
                });
            }
            return ordersDetails;
        }

        public OrdersDetails GetAllOrdersById(SqlDataReader dataReader)
        {
            OrdersDetails ordersDetails = new OrdersDetails();
            while (dataReader.Read())
            {
                ordersDetails = new OrdersDetails()
                {
                    FirstName = dataReader["FirstName"].ToString(),
                    TiffinName = dataReader["TiffinName"].ToString(),
                    TiffinDescription = dataReader["TiffinDescription"].ToString(),
                    Price = dataReader["Price"].ToString(),
                    ImageURL = dataReader["ImageURL"].ToString(),
                    EndDate = dataReader["EndDate"].ToString(),
                    StartDate = dataReader["StartDate"].ToString(),
                };
            }
            return ordersDetails;
        }

        public Login LoginResponse(SqlDataReader dataReader)
        {
            Login addResponse = new Login();
            while (dataReader.Read())
            {
                addResponse = new Login()
                {
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    AadharNumber = dataReader["AadharNumber"].ToString(),
                    EmailId = dataReader["EmailId"].ToString(),
                    Role = dataReader["Role"].ToString(),
                    Id = Convert.ToInt32(dataReader["id"]),
                };
            }
            return addResponse;
        }

        public List<Login> MapGetRoleBaseDetails(SqlDataReader dataReader)
        {
            List<Login> addResponse = new List<Login>();
            while (dataReader.Read())
            {
                addResponse.Add(new Login()
                {
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    AadharNumber = dataReader["AadharNumber"].ToString(),
                    EmailId = dataReader["EmailId"].ToString(),
                    Role = dataReader["Role"].ToString(),
                });
            }
            return addResponse;
        }

    }
}
