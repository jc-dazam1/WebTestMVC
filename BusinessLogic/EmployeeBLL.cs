using WebTestMVC.Models;

namespace WebTestMVC.BusinessLogic
{
    public class EmployeeBLL
    {
        public float CalculateAnnualSalary(Employee employee)
        {
            float employeeSalaryAnual = employee.EmployeeSalary * 12;
            employee.EmployeeAnualSalary = employeeSalaryAnual;
            return employee.EmployeeAnualSalary;
        }
    }
}
