using System.Data.SqlClient;
using TiffinManagement.ModelServices.Request;

namespace TiffinManagement.Repository.Interface
{
    public interface IDeliveryServices
    {
        Task<SqlDataReader> AddDeliveryDetails(DeliveryAddress deliveryAddress);
        Task<SqlDataReader> AddDeliveryHolderDetails(DeliveryHolderDetails deliveryHolder);
        Task<SqlDataReader> GetDeliveryHolderDetails();
        Task<SqlDataReader> GetDeliveryDetails();
    }
}
