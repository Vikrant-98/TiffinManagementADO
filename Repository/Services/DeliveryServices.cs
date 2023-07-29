﻿using System.Data;
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
         
        public async Task<SqlDataReader> AddDeliveryDetails(DeliveryAddress deliveryAddress,int userId) 
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spAddAddress", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Adderess", deliveryAddress.Address);
                    command.Parameters.AddWithValue("@Area", deliveryAddress.Area);
                    command.Parameters.AddWithValue("@Pin", deliveryAddress.Pin);
                    command.Parameters.AddWithValue("@UserId", userId);

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
                using (SqlCommand command = new SqlCommand("spAddUserDetail", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", deliveryHolder.FirstName);
                    command.Parameters.AddWithValue("@LastName", deliveryHolder.LastName);
                    command.Parameters.AddWithValue("@Email", deliveryHolder.Email);
                    command.Parameters.AddWithValue("@Password", deliveryHolder.Password);
                    command.Parameters.AddWithValue("@Role", deliveryHolder.Role);
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
                using (SqlCommand command = new SqlCommand("spGetRoleDetails", _dBService.Connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Role", "Delivery");
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

        public async Task<SqlDataReader> GetDeliveryDetailsById(int UserId) 
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
        
        public async Task<SqlDataReader> GetAllDeliveryDetails()
        {
            SqlDataReader dataReader;
            try
            {
                using (SqlCommand command = new SqlCommand("spGetOrderDetails", _dBService.Connection))
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
