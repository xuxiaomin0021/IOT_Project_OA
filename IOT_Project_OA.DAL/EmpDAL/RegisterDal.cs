 
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace IOT_Project_OA.DAL
{
    public class RegisterDal : IRegisterDal
    {
        DapperHelper helper = new DapperHelper();

        public int AddRole(Base_Role model)
        {
            return helper.AddData(model);
        }

        public int AddRoleAndQuan(int Q_ID, int R_ID)
        {
            Base_QuanAndRole model = new Base_QuanAndRole() { Quan_ID = Q_ID, Role_ID=R_ID };
            return helper.AddData(model);
        }

        public int AddUserAndRole(Base_RoleAndUser model)
        {
            return helper.AddData<Base_RoleAndUser>(model);
        }

        public List<Base_QuanAndRole> GetQandRList()
        {
            return helper.GetToList<Base_QuanAndRole>();
        }

        public List<Base_Quan> GetQuanList()
        {
            return helper.GetToList<Base_Quan>();
        }

        public List<Base_Role> GetRoleList()
        {
            return helper.GetToList<Base_Role>();
        }

        public List<Base_RoleAndUser> GetUandRList()
        {
            return helper.GetToList<Base_RoleAndUser>();
        }

        public List<Base_User> GetUserList()
        {
            return helper.GetToList<Base_User>();
        }

        public List<Base_Quan> Select()
        {
            return helper.GetToList<Base_Quan>();
        }

    }
}
