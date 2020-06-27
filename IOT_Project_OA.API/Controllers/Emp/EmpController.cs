using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IOT_Project_OA.BLL;
using IOT_Project_OA.DAL;
using IOT_Project_OA.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace IOT_Project_OA.API.Controllers.Emp
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCores")]
    public class EmpController : ControllerBase
    {
        IEmpBLLInterface bll;
        private IWebHostEnvironment _hostEnvironment;

        //依赖注入
        public EmpController(IEmpBLLInterface _bll, IWebHostEnvironment hostEnvironment)
        {
            bll = _bll;
            _hostEnvironment = hostEnvironment;

        }

        
        [HttpGet]
        public string order(int page,int limit, string emp_Name)
        {
            ProcDataAndTotal<Base_Emp_Information> proc = bll.ProcPageData(emp_Name, page);
            //string order = "Emp_ID,Entry_Time,Emp_Dept,Emp_Post,Emp_Sex,Nominal_Family,Emp_Code,Native_Place,Registered_Residence,[Political _Outlook],Born_Time,Family_Telephone,Specialty,Remarks,Now_Address,Phone,Health,Hobby,Emp_Picture,Emp_Name";
            string sJson = "{\"code\": " + 0 + ",\"msg\": \"\",\"count\":" + proc.Total + ",\"data\":" + JsonConvert.SerializeObject(proc.ProcData) + "}";

            /*
            int total = 0;
            string order = "ID,Order_Depart,Order_PlaceOfDeparture,Order_Destination,Order_CarriageDriver,Order_CustomerName,Order_VehicleModel,Order_TypeOfGoods,CreateDate,Order_Aging,Order_State";
            List<Base_Emp_Information> models = bll.GetOrderList<Base_Emp_Information>("proc_Order_List", "[dbo].[tb_ OrderForm]", order, "", "ID", limit, page, ref total);
            string sJson = "{\"code\": " + 0 + ",\"msg\": \"\",\"count\":" + total + ",\"data\":" + JsonConvert.SerializeObject(models) + "}";
            return sJson;
            */
            return sJson;
        }
        

        [HttpPost]
        public int DeleteEmp([FromForm]string deleteIds)
        {
            int code = bll.DeleteEmpTable(deleteIds);
            return code;
        }

        public Base_Emp_Information GetEmpModel(Guid id)
        {
            Base_Emp_Information model = bll.GetFirstData(id);
            if (model != null)
            {
                return model;
            }
            return null;
        }

        [HttpPost]
        public int UpdateEmp([FromForm]Base_Emp_Information model)
        {
            if (model.Emp_ID == null)
            {
                return 0;
            }
            return bll.Upemp(model);
        }


       
        

        [HttpPost]
        public int AddEmp(string obj)
        {
            Base_Emp_Information model = JsonConvert.DeserializeObject<Base_Emp_Information>(obj);
            model.Emp_ID = Guid.NewGuid();
            model.Political_Outlook = "团员";
            model.Entry_Time = model.Entry_Time.ToString();
            model.Health = "健康";
            model.Emp_Post = "部门员工";
            if (Request.Form.Files.Count > 0)
            {
                //http://localhost:49233+/Files/%E6%96%B0%E5%BB%BA%E6%96%87%E6%9C%AC%E6%96%87%E6%A1%A3.html
                //获取物理路径 webtootpath
                string path = _hostEnvironment.ContentRootPath + "\\wwwroot\\Files";
                //判断是否已经有该文件夹,如果没有,则进行创建
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //获取到后台传递过来的图片
                var file = Request.Form.Files[0];
                //判读图片格式是Jpg,Png还是其他
                string fileExt = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                //图片的名称
                string filename = Guid.NewGuid().ToString() + "." + fileExt;
                //保存到文件夹绝对路径
                string fileFullName = path + "\\" + filename;
                //判断是否已经有该图片,如果没有,则进行创建
                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                 model.Emp_Picture = "/Files/" + filename;
            }
            return bll.AddEmp(model);
        }


    }
}
