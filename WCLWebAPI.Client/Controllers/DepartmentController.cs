using Microsoft.AspNetCore.Mvc;

namespace WCLWebAPI.Client.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
