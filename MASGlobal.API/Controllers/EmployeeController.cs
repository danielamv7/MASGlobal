using MASGlobal.BL.Interfaces;
using MASGlobal.BL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MASGlobal.API.Controllers
{
    public class EmployeeController : ApiController
    {
        private Employee employee = new Employee();

        [Route("GetAll")]
        public async Task<HttpResponseMessage> GetEmployees()
        {
            var result = await employee.GetAllEmployees();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
        [Route("GetById")]
        public async Task<HttpResponseMessage> GetEmployee(int id)
        {
            var result = await employee.GetEmployee(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
