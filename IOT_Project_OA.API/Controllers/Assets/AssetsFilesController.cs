using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IOT_Project_OA.BLL;
using IOT_Project_OA.Model;
using IOT_Project_OA.BLL.IBLL.AssetsIBLL;
using IOT_Project_OA.DAL;
using IOT_Project_OA.API.Models;
using System.Reflection;

namespace IOT_Project_OA.API.Controllers.Assets
{
    [Route("Files")]
    [ApiController]
    public class AssetsFilesController : ControllerBase
    {
        //依赖注入BLL
        private FilesIBLL _filesbll;
        public AssetsFilesController(FilesIBLL filesbll)
        {
            _filesbll = filesbll;
        }

        //显示所有数据存储过程分页
        [Route("ProcGetFilesdata")]
        [HttpGet]
        public ProcDataAndTotal<Base_Assete_Files> ProcGetFilesdata(int pageIndex,int pageSize)
        {
            ProcDataAndTotal<Base_Assete_Files> proc = _filesbll.ProcPageData("", pageIndex,pageSize);
            return proc;
        }

        //显示存储过程分页查询
        [Route("SelectProcData")]
        [HttpGet]
        public ProcDataAndTotal<Base_Assete_Files> SelectProcData(SelectFilesClass selectmodel)
        {
            //页码
            int pageIndex = selectmodel.PageIndex;
            //查询的条件语句
            string wheresql = "";
            Type t = selectmodel.GetType();
            PropertyInfo[] properties = t.GetProperties();
            foreach (var item in properties)
            {
                //模糊查询
                if(item.Name == "Assets_Name")
                {
                    wheresql += $" and {item.Name} like '%'" + item.GetValue(selectmodel) + "'%'";
                }
                if(item.GetValue(selectmodel).ToString()!=null && item.Name!= "PageIndex" && item.Name != "Assets_Name")
                {
                    wheresql += $" and {item.Name} = '{item.GetValue(selectmodel)}'";
                }
            }
            ProcDataAndTotal<Base_Assete_Files> proc = _filesbll.ProcPageData(wheresql, pageIndex,5);
            return proc;
        }

        [Route("GetFristData")]
        [HttpGet]
        //获取一条详细的数据
        public Base_Assete_Files GetFristData(string Id)
        {
            return _filesbll.GetFirstData(Id);
        }


        //添加一条数据
        [HttpPost]
        [Route("InsertData")]
        public int InsertData(Base_Assete_Files files)
        {
            return _filesbll.InsertFiles(files);
        }

        //删除一条数据
        [Route("DeleteData")]
        [HttpPost]
        public int DeleteData(string Id)
        {
            return _filesbll.DeleteFiles(Id);
        }
    }
}