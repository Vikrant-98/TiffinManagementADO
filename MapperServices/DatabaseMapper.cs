﻿using System.Data.SqlClient;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagement.MapperServices
{
    public class DatabaseMapper
    {
        public List<TiffinDetails> GetAllTiffin(SqlDataReader dataReader) 
        {
            List<TiffinDetails> bookList = new List<TiffinDetails>();
            while (dataReader.Read())
            {
                bookList.Add(new TiffinDetails
                {
                    Id = Convert.ToInt32(dataReader["ID"]),
                    Name = dataReader["Name"].ToString(),
                    Description = dataReader["Description"].ToString(),
                    Price = Convert.ToInt32(dataReader["Price"]),
                    Image = dataReader["Images"].ToString()
                });
            }
            return bookList;
        }

        public AddResponse AddUpdateDeleteResponse(SqlDataReader dataReader) 
        {
            AddResponse addResponse = new AddResponse();
            while (dataReader.Read())
            {
                addResponse  = new AddResponse()
                {
                    Message = dataReader["ResponseMessage"].ToString(),
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
