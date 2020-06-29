using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IOT_Project_OA.BLL;
using IOT_Project_OA.Model;
using IOT_Project_OA.BLL.IBLL.AssetsIBLL;

namespace IOT_Project_OA.API.Controllers.Assets
{
    [Route("Assetsclass")]
    [ApiController]
    public class AssetsClassController : ControllerBase
    {
        private FilesclassIBLL _filesclass;

        public AssetsClassController(FilesclassIBLL filesclass)
        {
            _filesclass = filesclass;
        }

        //显示所有的资产类型
        [Route("GetclassData")]
        [HttpGet]
        public List<Assets_Class> GetclassData()
        {
            return _filesclass.GetClassData();
        }


        //添加资产类型
        [Route("AddClassData")]
        [HttpPost]
        public int AddClassData(Assets_Class aclass)
        {
            return _filesclass.AddFilesClass(aclass);
        }


        //删除资产类型
        public int Deleteclass(string Id)
        {
            return _filesclass.DeleteFilesClass(Id);
        }
    }
}