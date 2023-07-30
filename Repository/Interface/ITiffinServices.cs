using System.Data.SqlClient;
using TiffinManagement.ModelServices.Request;

namespace Repository.Interface
{
    public interface ITiffinServices
    {
        Task<SqlDataReader> GetAllTiffin();
        Task<SqlDataReader> AddTiffin(AddTiffin addTiffin,int Id);
        Task<SqlDataReader> EditTiffin(AddTiffinModifier addTiffin,string ImageUrl);
        Task<SqlDataReader> DeleteTiffin(int id);
    }
}
