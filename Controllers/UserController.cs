using Microsoft.AspNetCore.Mvc;
using TiffinManagement.Business.Interface;

namespace TiffinManagement.Controllers
{
    public class UserController : Controller
    {
        private IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness) 
        {
            _userBusiness = userBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
