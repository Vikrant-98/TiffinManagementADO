using System.Data.SqlClient;
using TiffinManagement.ModelServices.Request;

namespace TiffinManagement.Repository.Interface
{
    public interface IDeliveryServices
    {
        Task<SqlDataReader> GetDeliveryDetailsById(int UserId);
        Task<SqlDataReader> GetAllDeliveryDetails();
        Task<SqlDataReader> GetDeliveryHolderDetails();
        Task<SqlDataReader> AddDeliveryHolderDetails(DeliveryHolderDetails deliveryHolder);
        Task<SqlDataReader> AddDeliveryDetails(DeliveryAddress deliveryAddress, int userId);
    }
}
