﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IOT_Project_OA.View.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 我的桌面
        /// </summary>
        /// <returns></returns>
        public IActionResult MyDeskTop()
        {
            return View();
        }


        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }



        //登录
        public IActionResult Login()
        {
            return View();
        } 


    }
}