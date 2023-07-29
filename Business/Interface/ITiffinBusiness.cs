using TiffinManagement.ModelServices.ProcessModel;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace Business.Interface
{
    public interface ITiffinBusiness
    {
        Task<List<TiffinDetails>> GetAllTiffin();
        Task<AddResponse> AddTiffin(AddTiffin addTiffin, int Id);
        Task<AddResponse> EditTiffin(AddTiffinModifier addTiffin);
        Task<AddResponse> DeleteTiffin(int id);
    }
}
