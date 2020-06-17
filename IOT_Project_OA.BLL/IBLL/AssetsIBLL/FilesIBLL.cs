using System;
using System.Collections.Generic;
using System.Text;
using IOT_Project_OA.Model;
using IOT_Project_OA.DAL;

namespace IOT_Project_OA.BLL.IBLL.AssetsIBLL
{
    //资产档案
    public interface FilesIBLL
    {
        /// <summary>
        /// 显示存储过程分页
        /// </summary>
        /// <param name="whereStr">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public ProcDataAndTotal<Base_Assete_Files> ProcPageData(string whereStr, int pageIndex);


        /// <summary>
        /// 删除资产档案
        /// </summary>
        /// <param name="files">资产档案model存取ID</param>
        /// <returns></returns>
        public int DeleteFiles(string Id);


        /// <summary>
        /// 详情获取一条数据
        /// </summary>
        /// <param name="Id">获取的数据的id</param>
        /// <returns></returns>
        public Base_Assete_Files GetFirstData(string Id);


        /// <summary>
        /// 添加一条资产档案
        /// </summary>
        /// <param name="model">获取到的model</param>
        /// <returns></returns>
        public int InsertFiles(Base_Assete_Files model);
    }
}
