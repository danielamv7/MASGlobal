using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MASGlobal.DAL.Interfaces;
using MASGlobal.DTO;
using MASGlobal.DTO.Support;
using Newtonsoft.Json;

namespace MASGlobal.DAL
{
    public class EmployeeRepository 
    {
       
       public async Task<List<DTOEmployeeJsonResult>> GetEmployees()
        {
            List<DTOEmployeeJsonResult> result = new List<DTOEmployeeJsonResult>();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(DTOHelper.UrlApi);
            string Jsonresult = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<List<DTOEmployeeJsonResult>>(Jsonresult);
            return result;
        }
    }
}
