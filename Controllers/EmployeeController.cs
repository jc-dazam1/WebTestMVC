using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using WebTestMVC.BusinessLogic;
using WebTestMVC.DAL;

namespace WebTestMVC.Controllers
{
    [EnableCors(origins: "https://localhost:7086", headers: "*", methods: "*")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDAL _employeeDAL;
        private readonly EmployeeBLL _employeeBLL;

        public EmployeeController(EmployeeDAL employeeDAL, EmployeeBLL employeeBLL)
        {
            _employeeDAL = employeeDAL;
            _employeeBLL = employeeBLL;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeDAL.GetEmployeesAsync();
            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeDAL.GetEmployeeByIdAsync(id);
            return View(employee);
        }

        public IActionResult CalculateAnnualSalary(int id)
        {
            var employee = _employeeDAL.GetEmployeeByIdAsync(id).Result;
            var annualSalary = _employeeBLL.CalculateAnnualSalary(employee);

            ViewBag.AnnualSalary = annualSalary;
            return View(employee);
        }
    }
}
