using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters;
using System.Text;
using IOT_Project_OA.DAL.IDAL.AssetsIDAL;
using IOT_Project_OA.Model;

namespace IOT_Project_OA.DAL.DAL.AssetsDAL
{
    //资产档案
    public class FilesDAL : FilesIDAL
    {
        DapperHelper dapper = new DapperHelper();
        /// <summary>
        /// 删除档案
        /// </summary>
        /// <param name="files">删除存取的id</param>
        /// <returns></returns>
        public int DeleteFiles(Base_Assete_Files files)
        {
            return dapper.DeleteData<Base_Assete_Files>(files);
        }

        /// <summary>
        /// 获取单条档案信息
        /// </summary>
        /// <param name="Id">根据id获取单条数据</param>
        /// <returns></returns>
        public Base_Assete_Files GetFirstData(string Id)
        {
            return dapper.GetToList<Base_Assete_Files>().Where(s=>s.Assets_ID.Equals(Id)).FirstOrDefault();
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">添加的数据</param>
        /// <returns></returns>
        public int InsertFiles(Base_Assete_Files model)
        {
            return dapper.AddData<Base_Assete_Files>(model);
        }

        /// <summary>
        /// 获取分页档案信息
        /// </summary>
        /// <param name="whereStr">条件</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public ProcDataAndTotal<Base_Assete_Files> ProcPageData(string whereStr, int pageIndex,int pageSize)
        {
            return dapper.GetProcData<Base_Assete_Files>("Base_Assete_Files", whereStr, "Assets_ID", pageIndex,pageSize);
        }
    }
}
