using Microsoft.AspNetCore.Mvc;
using TiffinManagement.Business.Interface;

namespace TiffinManagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderBusiness _orderBusiness;

        OrderController(IOrderBusiness orderBusiness) 
        {
            _orderBusiness = orderBusiness;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
