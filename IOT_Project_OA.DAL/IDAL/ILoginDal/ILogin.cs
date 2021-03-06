﻿using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.DAL.IDAL.ILoginDal
{
    public interface ILogin
    {
        //登录
        Base_User Select(Base_User user);
        //授权 
        int Add(Base_User user);
        List<Base_User> GetUserList();
        int Delete(Base_User user);



    }
}
