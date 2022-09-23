using CRUD.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers.Ajax
{
    public class AjaxController : Controller
    {
        private readonly ApplicationContext context;

        public AjaxController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult EmployeeList()
        {
            var data = context.Employees.ToList();
            return new JsonResult(data);
        }
    }
}
