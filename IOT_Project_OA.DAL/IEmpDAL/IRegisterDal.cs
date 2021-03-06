﻿using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IOT_Project_OA.DAL
{
   public interface IRegisterDal
    {
       List<Base_Quan> Select();
        //  int Add(Base_Role role,List<Base_QuanAndRole> roles);

        int AddRole(Base_Role model);

        int AddRoleAndQuan(int Q_ID, int R_ID);

        List<Base_Role> GetRoleList();

        List<Base_User> GetUserList();

        int AddUserAndRole(Base_RoleAndUser model);

        List<Base_RoleAndUser> GetUandRList();
      
        List<Base_Quan> GetQuanList();

        List<Base_QuanAndRole> GetQandRList();


    }
}
