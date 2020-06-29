using Dapper;
using IOT_Project_OA.DAL.IDAL.ILoginDal;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.InteropServices;

namespace IOT_Project_OA.DAL.DAL.LoginDal
{
    public class Login : ILogin
    {
        private readonly DapperHelper helper = new DapperHelper();

        //创建用户
        public int Add(Base_User user)
        {
            int h = helper.InsertData(user);
            return h;

        }

        public List<Base_User> GetUserList()
        {
            return helper.GetToList<Base_User>();
        }

        //获取登录数据
        public Base_User Select(Base_User user)
        {
            Base_User list = helper.GetLoginData<Base_User>(user.User_Name, user.User_Pwd).FirstOrDefault();
            return list;

        }

    }
}
