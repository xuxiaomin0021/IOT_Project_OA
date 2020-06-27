using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.BLL
{
   public interface IRegisterBLL
    {
        List<Base_Quan> Select();


        int AddRole(Base_Role model);

        int AddRoleAndQuan(int Q_ID, int R_ID);

        List<Base_Role> GetRoleList();

    }
}
