using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOT_Project_OA.DAL.EmpDAL
{
    public class EmpDAL : IEmpDAL
    {

        DapperHelper dapper = new DapperHelper();


        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddEmp(Base_Emp_Information model)
        {
            return dapper.AddData(model);
        }

        /// <summary>
        /// 单删批删数据
        /// </summary>
        /// <param name="deleteIds"></param>
        /// <returns></returns>
        public int DeleteEmpTable(string deleteIds)
        {
            return dapper.SingerAndBatchDeleteTable("Dele_Table", "Base_Emp_Information", "Emp_ID", deleteIds);
        }

        /// <summary>
        /// 编辑通过ID找到一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Base_Emp_Information GetFirstData(Guid Id)
        {
            return dapper.GetToList<Base_Emp_Information>().Where(s => s.Emp_ID.Equals(Id)).FirstOrDefault();
        }


        /// <summary>
        /// 显示分页存储过程
        /// </summary>
        /// <param name="whereStr"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ProcDataAndTotal<Base_Emp_Information> ProcPageData(string whereStr, int pageIndex, int pageSize)
        {
            if(whereStr != null)
            {
                whereStr = $" and Emp_Name like '%{whereStr}%'";
            }
            ProcDataAndTotal<Base_Emp_Information> list = dapper.GetProcData<Base_Emp_Information>("Base_Emp_Information", whereStr,"Entry_Time", pageIndex,pageSize);
            return list;
        }

        /// <summary>
        /// 修改存储过程   四个字段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Upemp(Base_Emp_Information model)
        {
            return dapper.UpdateEmp("Emp_Update",model);
        }



    }
}
