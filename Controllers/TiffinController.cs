using Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiffinManagement.ModelServices.Request;
using TiffinManagement.ModelServices.Response;

namespace TiffinManagementAPI.Controllers
{
    public class TiffinController : Controller
    {
        private readonly ITiffinBusiness _TiffinBusiness;

        public TiffinController(ITiffinBusiness TiffinBusiness) 
        {
            _TiffinBusiness = TiffinBusiness;
        }

        [HttpGet("GetAllTiffin")]
        [Authorize(Roles = "Admin")]
        public async Task<List<TiffinDetails>> GetAllTiffin()
        {
            List<TiffinDetails> tiffinDetails = new List<TiffinDetails>();
            try 
            {
                tiffinDetails = await _TiffinBusiness.GetAllTiffin().ConfigureAwait(false);
            }
            catch (Exception)
            {

                throw;
            }
            
            return tiffinDetails;
        }

        [HttpPost("AddTiffin")]
        [Authorize(Roles = "Admin")]
        public async Task<AddResponse> AddTiffin([FromBody] AddTiffinRequest addTiffin)
        {
            AddResponse? Response = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserId").Value);
                Response = await _TiffinBusiness.AddTiffin(addTiffin, userId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }            
            return Response;
        }

        [HttpPost("EditTiffin")]
        [Authorize(Roles = "Admin")]
        public async Task<AddResponse> EditTiffin([FromBody] AddTiffinModifier addTiffin)
        {
            AddResponse? Result = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserId").Value);
                Result = await _TiffinBusiness.EditTiffin(addTiffin).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }            
            return Result;
        }

        [HttpDelete("{TiffinId}")]
        [Authorize(Roles = "Admin")]
        public async Task<AddResponse> DeleteTiffin(int TiffinId)
        {
            AddResponse? Result = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int userId = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "UserId").Value);
                Result = await _TiffinBusiness.DeleteTiffin(TiffinId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            
            return Result;
        }

    }
}
