using IOT_Project_OA.DAL;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.BLL
{
    public class EmpBLL : IEmpBLLInterface
    {
        IEmpDAL dal;
        //依赖注入
        public EmpBLL(IEmpDAL _dal)
        {
            dal = _dal;
        }

        public int AddEmp(Base_Emp_Information model)
        {
            return dal.AddEmp(model);
        }

        public int DeleteEmpTable(string deleteIds)
        {
            return dal.DeleteEmpTable(deleteIds);
        }

        public Base_Emp_Information GetFirstData(Guid Id)
        {
            return dal.GetFirstData(Id);
        }

        public ProcDataAndTotal<Base_Emp_Information> ProcPageData(string whereStr, int pageIndex)
        {
            return dal.ProcPageData(whereStr, pageIndex);
        }

        public int Upemp(Base_Emp_Information model)
        {
            return dal.Upemp(model);
        }


    }
}
