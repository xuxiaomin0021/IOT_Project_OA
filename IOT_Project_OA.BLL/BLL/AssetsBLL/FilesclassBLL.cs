using IOT_Project_OA.BLL.IBLL.AssetsIBLL;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Text;
using IOT_Project_OA.DAL;
using IOT_Project_OA.DAL.IDAL.AssetsIDAL;

namespace IOT_Project_OA.BLL.BLL.AssetsBLL
{
    public class FilesclassBLL : FilesclassIBLL
    {
        //依赖注入
        private FilesclassIDAL _filesclassDal;
        public FilesclassBLL(FilesclassIDAL filesclassDal)
        {
            _filesclassDal = filesclassDal;
        }

        /// <summary>
        /// 添加资产类别
        /// </summary>
        /// <param name="classModel"></param>
        /// <returns></returns>
        public int AddFilesClass(Assets_Class classModel)
        {
            return _filesclassDal.AddFilesClass(classModel);
        }

        /// <summary>
        /// 删除资产类别
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public int DeleteFilesClass(string classId)
        {
            Assets_Class assets = new Assets_Class() {
                Asset_TypeID = int.Parse(classId)
            };
            return _filesclassDal.DeleteFilesClass(assets);
        }


        /// <summary>
        /// 显示所有的资产信息
        /// </summary>
        /// <returns></returns>
        public List<Assets_Class> GetClassData()
        {
            return _filesclassDal.GetClassData();
        }
    }
}
