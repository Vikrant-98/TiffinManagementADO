using System.Data.SqlClient;
using TiffinManagement.ModelServices.ProcessModel;

namespace Repository.Interface
{
    public interface ITiffinServices
    {
        Task<SqlDataReader> GetAllTiffin();
        Task<SqlDataReader> AddTiffin(AddTiffinModifier addTiffin);
        Task<SqlDataReader> EditTiffin(AddTiffinModifier addTiffin);
        Task<SqlDataReader> DeleteTiffin(int id);
    }
}
