using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOT_Project_OA.View.Controllers.AssetsFiles
{
    public class FilesController : Controller
    {
        public IActionResult ShowFiles()
        {
            return View();
        }
    }
}