using Business.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TiffinManagementAPI.Controllers
{
    public class TiffinController : Controller
    {
        private readonly ITiffinBusiness _TiffinBusiness;

        public TiffinController(ITiffinBusiness TiffinBusiness) 
        {
            _TiffinBusiness = TiffinBusiness;
        }

        [HttpPost("AddStocks")]
        public async Task<bool> AddStocks([FromBody] AddStocks userStocks)
        {
            return true;
        }

        [HttpGet("GetAllStocks")]
        public List<Stocks> GetAllStocks()
        {
            return new List<Stocks>();
        }

        [HttpGet("GetAllCustomerStocks")]

        public List<CustomerStocks> GetAllCustomerStocks(int CustomerId)
        {
            return new List<CustomerStocks>();
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
