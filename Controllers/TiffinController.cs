using Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TiffinManagement.ModelServices.ProcessModel;
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
        public async Task<List<TiffinDetails>> AddStocks()
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
        public async Task<AddResponse> GetAllStocks(AddTiffin addTiffin)
        {
            AddResponse? Response = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int adminID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "AdminID").Value);
                Response = await _TiffinBusiness.AddTiffin(addTiffin, adminID).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }            
            return Response;
        }

        [HttpPost("EditTiffin")]
        public async Task<AddResponse> EditTiffin(AddTiffinModifier addTiffin)
        {
            AddResponse? Result = new AddResponse();
            try
            {
                var user = HttpContext.User;
                int adminID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "AdminID").Value);
                Result = await _TiffinBusiness.EditTiffin(addTiffin).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }            
            return Result;
        }

        [HttpPost("AddCustomerStocks")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> AddCustomerStocks([FromBody] AddCustomerStocks stocks)
        {
            
           return true;
        }

        [HttpPost("RemoveCustomerStocks")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> RemoveCustomerStocks([FromBody] AddCustomerStocks stocks)
        {
            
            return true ;
        }
    }
}
