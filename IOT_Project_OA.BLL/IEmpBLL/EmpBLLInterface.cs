using IOT_Project_OA.DAL;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.BLL
{
    public interface IEmpBLLInterface
    {
        /// <summary>
        /// 显示存储过程分页
        /// </summary>
        /// <param name="whereStr">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public ProcDataAndTotal<Base_Emp_Information> ProcPageData(string whereStr, int pageIndex);


        public int DeleteEmpTable(string deleteIds);

        public Base_Emp_Information GetFirstData(Guid Id);
        public int Upemp(Base_Emp_Information model);

        public int AddEmp(Base_Emp_Information model);


    }
}
