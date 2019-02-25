using MASGlobal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MASGlobal.DTO;
using System.Threading.Tasks;

namespace MASGlobal.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployees(string id)
        {

            ViewBag.Message = "Employee Administration page.";
            EmployeeData employee = new EmployeeData();
            List<object> results = new List<object>();
            Employee Resultemployee;
            if (String.IsNullOrEmpty(id))
            {
                return Json(Task.Run(async () => { return await employee.GetAllEmployees(); }).Result, JsonRequestBehavior.AllowGet); 
            }
            else
            {
                Resultemployee = Task.Run(async () => { return await employee.GetEmployee(id); }).Result;
                results.Add(Resultemployee);
                return Json(results, JsonRequestBehavior.AllowGet);
            }
           
        }
    }
}
