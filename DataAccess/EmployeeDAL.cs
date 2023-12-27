using Newtonsoft.Json;
using WebTestMVC.Models;

namespace WebTestMVC.DAL
{
    public class EmployeeDAL
    {
        private readonly HttpClient _httpClient;

        public EmployeeDAL()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1/")
            };
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var response = await _httpClient.GetAsync("employees");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Employee>>(content);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"employee/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(content);
        }
    }
}
