using IOT_Project_OA.BLL.IBLL.AssetsIBLL;
using IOT_Project_OA.DAL;
using IOT_Project_OA.DAL.IDAL.AssetsIDAL;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.BLL.BLL.AssetsBLL
{
    //资产档案
    public class FilesBLL : FilesIBLL
    {
        //依赖注入dal
        private FilesIDAL _filesDal;
        public FilesBLL(FilesIDAL filesDal)
        {
            _filesDal = filesDal;
        }

        /// <summary>
        /// 删除档案
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public int DeleteFiles(string Id)
        {
            Base_Assete_Files files = new Base_Assete_Files() { 
            Assets_ID = Guid.Parse(Id)
            };
            return _filesDal.DeleteFiles(files);
        }

        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Base_Assete_Files GetFirstData(string Id)
        {
            return _filesDal.GetFirstData(Id);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertFiles(Base_Assete_Files model)
        {
            return _filesDal.InsertFiles(model);
        }

        /// <summary>
        /// 存储过程分页
        /// </summary>
        /// <param name="whereStr"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ProcDataAndTotal<Base_Assete_Files> ProcPageData(string whereStr, int pageIndex,int pageSize)
        {
            return _filesDal.ProcPageData(whereStr,pageIndex,pageSize);
        }
    }
}
