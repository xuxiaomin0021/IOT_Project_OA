﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading.Tasks;
using IOT_Project_OA.BLL.IBLL.ILoginBLL;
using IOT_Project_OA.DAL;
using IOT_Project_OA.Model;
using IOT_Project_OA.View;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using WebApplication72.Models;

namespace IOT_Project_OA.API.Controllers.UserLogin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCores")]
    public class UserLoginController : ControllerBase
    {
        JWTHelper WTHelper = new JWTHelper();
        private readonly ILoginBll loginBll;
        public UserLoginController(ILoginBll _loginBll)
        {
            loginBll = _loginBll;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public string Login([FromForm]Base_User model)
        {
            try
            {
                //得到登录的数据 
                Base_User user = loginBll.Select(model);
                //判断得到的数据是否为空，为空跳转注册
                if (user != null)
                { 
                    //定义字典存放用户登录的信息
                    Dictionary<string, object> keys = new Dictionary<string, object>();
                    keys.Add("User_Name", user.User_Name);
                    keys.Add("User_ID", user.User_ID);
                    keys.Add("User_Pwd", user.User_Pwd);
                    //得到toekn，给他失效时间
                    string token = WTHelper.GetToken(keys, 30000);
                    //登录成功 
                    return token;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public int Register([FromForm]Base_User model)
        {
            try
            {

                if (model != null)
                {
                    int h = loginBll.Add(model);
                    if (h > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}