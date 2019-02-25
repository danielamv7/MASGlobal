using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MASGlobal.DTO;
using MASGlobal.DTO.Support;
using Newtonsoft.Json;

namespace MASGlobal.Web.Models
{
    public class EmployeeData
    {

        public async Task<List<Employee>> GetAllEmployees()
        {
            DTOResult<List<Employee>> GetEmployeeResponse = new DTOResult<List<Employee>>();
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(DTOHelper.UrlLocal + "GetAll");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            GetEmployeeResponse = JsonConvert.DeserializeObject<DTOResult<List<Employee>>>(content);
            List<Employee> employeesResult = GetEmployeeResponse.Data;
            return employeesResult;
        }

        public async Task<Employee> GetEmployee(string id)
        {
            Employee GetEmployeeResponse;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(DTOHelper.UrlLocal + "GetById?id=" + id);
            response.EnsureSuccessStatusCode();
            DTOResult<Employee> GetEmployee = new DTOResult<Employee>();
            string content = await response.Content.ReadAsStringAsync();
            GetEmployee = JsonConvert.DeserializeObject<DTOResult<Employee>>(content);
            GetEmployeeResponse = GetEmployee.Data;
            return GetEmployeeResponse;
        }
    }
}