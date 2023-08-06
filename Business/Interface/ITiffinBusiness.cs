using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace Business.Interface
{
    public interface ITiffinBusiness
    {
        Task<List<TiffinDetails>> GetAllTiffin();
        Task<AddResponse> AddTiffin(AddTiffinRequest addTiffin, int Id,IFormFile formFile);
        Task<AddResponse> EditTiffin(AddTiffinModifier addTiffin,IFormFile formFile);
        Task<AddResponse> DeleteTiffin(int id);
        Task<AddResponse> AddReview(AddTiffinReview addTiffinReview, int Id);
    }
}
