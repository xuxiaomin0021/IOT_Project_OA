using System;
using System.Collections.Generic;
using System.Text;
using IOT_Project_OA.DAL;
using IOT_Project_OA.Model;

namespace IOT_Project_OA.BLL.IBLL.AssetsIBLL
{
    public interface FilesclassIBLL
    {
        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="classModel">添加类型的model</param>
        /// <returns></returns>
        public int AddFilesClass(Assets_Class classModel);

        /// <summary>
        /// 删除类型
        /// </summary>
        /// <param name="classId">删除类型的model存ID</param>
        /// <returns></returns>
        public int DeleteFilesClass(string Id);


        /// <summary>
        /// 显示所有的商品的类别
        /// </summary>
        /// <returns></returns>
        public List<Assets_Class> GetClassData();
    }
}
