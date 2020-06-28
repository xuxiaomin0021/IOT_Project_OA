using IOT_Project_OA.DAL;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.BLL
{
    public class RegisterBLL : IRegisterBLL
    {
        public IRegisterDal dal;
        public RegisterBLL(IRegisterDal _dal)
        {
            dal = _dal;
        }

        public int AddRole(Base_Role model)
        {
            return dal.AddRole(model);
        }

        public int AddRoleAndQuan(int Q_ID, int R_ID)
        {
            return dal.AddRoleAndQuan(Q_ID, R_ID);
        }

        public int AddUserAndRole(Base_RoleAndUser model)
        {
            return dal.AddUserAndRole(model);
        }

        public List<Base_Role> GetRoleList()
        {
            return dal.GetRoleList();
        }

        public List<Base_User> GetUserList()
        {
            return dal.GetUserList();
        }

        public List<Base_Quan> Select()
        {
            return dal.Select();
        }
    }
}
