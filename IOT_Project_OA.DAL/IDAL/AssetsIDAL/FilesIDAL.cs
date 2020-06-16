using System;
using System.Collections.Generic;
using System.Text;
using IOT_Project_OA.Model;

namespace IOT_Project_OA.DAL.IDAL.AssetsIDAL
{
    //资产档案
    public interface FilesIDAL
    {
        /// <summary>
        /// 显示存储过程分页
        /// </summary>
        /// <param name="tableName">要分页的表名</param>
        /// <param name="orderField">排序的字段</param>
        /// <param name="whereStr">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        public ProcDataAndTotal<Base_Assete_Files> ProcPageData(string tableName,string orderField,string whereStr,int pageIndex);


        /// <summary>
        /// 删除资产档案
        /// </summary>
        /// <param name="files">资产档案model存取ID</param>
        /// <returns></returns>
        public int DeleteFiles(Base_Assete_Files files);

        
    }
}
