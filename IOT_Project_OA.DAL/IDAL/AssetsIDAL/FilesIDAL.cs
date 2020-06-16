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
        /// 删除资产档案
        /// </summary>
        /// <param name="files">资产档案model存取ID</param>
        /// <returns></returns>
        public int DeleteFiles(Base_Assete_Files files);
    }
}
