using IOT_Project_OA.DAL.IDAL.AssetsIDAL;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Text;
using IOT_Project_OA.Model;

namespace IOT_Project_OA.DAL.DAL.AssetsDAL
{
    public class FilesclassDAL : FilesclassIDAL
    {
        DapperHelper dapper = new DapperHelper();
        /// <summary>
        /// 添加资产类别
        /// </summary>
        /// <param name="classModel"></param>
        /// <returns></returns>
        public int AddFilesClass(Assets_Class classModel)
        {
            return dapper.AddData<Assets_Class>(classModel);
        }

        /// <summary>
        /// 删除资产类别
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public int DeleteFilesClass(Assets_Class classId)
        {
            return dapper.DeleteData<Assets_Class>(classId);
        }

        /// <summary>
        /// 显示所有的资产类别
        /// </summary>
        /// <returns></returns>
        public List<Assets_Class> GetClassData()
        {
            return dapper.GetToList<Assets_Class>();
        }
    }
}
