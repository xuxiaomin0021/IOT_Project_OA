using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;

namespace IOT_Project_OA.View.Controllers.SaleAdmin
{
    public class SaleAdminController : Controller
    {
        /// <summary>
        /// 销售管理显示
        /// </summary>
        /// <returns></returns>
        public IActionResult SaleShow()
        {
            return View();
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="sale_ID"></param>
        /// <returns></returns>
        public IActionResult Detail(Guid sale_ID)
        {
            ViewBag.ID = sale_ID;
            return View();
        }
        /// <summary>
        /// 新增拜访
        /// </summary>
        /// <returns></returns>
        public IActionResult SaleAdd()
        {
            return View();
        }
        /// <summary>
        /// 外勤签到管理
        /// </summary>
        /// <returns></returns>
        public IActionResult SignInShow()
        {
            return View();
        }
        /// <summary>
        /// 拜访记录
        /// </summary>
        /// <returns></returns>
        public IActionResult VisitShow()
        {
            return View();
        }
        /// <summary>
        /// 添加外勤签到信息
        /// </summary>
        /// <returns></returns>
        public IActionResult QianDaoAdd()
        {
            return View();
        }
    }
}