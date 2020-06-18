using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOT_Project_OA.View.Controllers.AssetsFiles
{
    public class FilesController : Controller
    {
        //显示
        public IActionResult ShowFiles()
        {
            return View();
        }

        //添加
        public IActionResult AddFiles()
        {
            return View();
        }
    }
}