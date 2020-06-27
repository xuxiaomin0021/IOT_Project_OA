using IOT_Project_OA.BLL.IBLL.ILoginBLL;
using IOT_Project_OA.DAL;
using IOT_Project_OA.DAL.IDAL.ILoginDal;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IOT_Project_OA.BLL.BLL.LoginBLL
{
    public class LoginBll : ILoginBll
    {
        private readonly ILogin login;
        public LoginBll(ILogin _login)
        {
            login = _login;
        }
        //授权添加 
        public int Add(Base_User user)
        {
            return login.Add(user);
        }
        //查询登录
        public Base_User Select(Base_User user)
        {
            return login.Select(user);
        }
       
    }
}
