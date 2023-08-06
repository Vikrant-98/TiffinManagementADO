using System.Data.SqlClient;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace Repository.Interface
{
    public interface ITiffinServices
    {
        Task<List<TiffinDetails>> GetAllTiffin();
        Task<AddResponse> AddTiffin(AddTiffin addTiffin,int Id);
        Task<AddResponse> EditTiffin(AddTiffinModifier addTiffin,string ImageUrl);
        Task<AddResponse> DeleteTiffin(int id);
        Task<AddResponse> AddTiffinRatings(AddTiffinReview addTiffin, int Id);
    }
}
