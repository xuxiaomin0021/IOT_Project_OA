using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOT_Project_OA.View.Controllers.Emp_Test
{
    public class EmpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditEmp(Guid id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpGet]
        public IActionResult AddEmp()
        {
            return View();
        }

    }
}
