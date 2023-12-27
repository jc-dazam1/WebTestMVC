using Microsoft.AspNetCore.Mvc;

namespace WebTestMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
