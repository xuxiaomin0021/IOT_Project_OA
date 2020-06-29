using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using IOT_Project_OA.BLL.IBLL.SaleIBLL;
using IOT_Project_OA.DAL;
using IOT_Project_OA.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IOT_Project_OA.API.Controllers.SaleAdmin
{
    [Route("api")]
    [ApiController]
    public class SaleAdminController : ControllerBase
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        public SaleaAdminIBLL _Salebll;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Salebll"></param>
        public SaleAdminController(SaleaAdminIBLL Salebll)
        {
            _Salebll = Salebll;
        }
        /// <summary>·
        /// 分页显示销售管理列表
        /// </summary>
        /// <param name="WhereStr"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSaleManagers")]
        public string GetSaleManagers(int Page, int limit,string dateTimestr, string baiFang_Name,string keHu_Name,string baiFang_Type,string state)
        {
            //查询条件
            string whereStr = "";
            //按拜访名称查询
            if(!string.IsNullOrEmpty(baiFang_Name))
            {
                whereStr += $" and Customer_Name like '%{baiFang_Name}%'";
            }
            //按客户名称查询
            if (!string.IsNullOrEmpty(keHu_Name))
            {
                whereStr += $" and Customer_Name like '%{keHu_Name}%'";
            }
            //按拜访类型查询
            if(!string.IsNullOrEmpty(baiFang_Type))
            {
                whereStr += $" and Visit_Type='{baiFang_Type}'";
            }
            //按状态查询
            if(!string.IsNullOrEmpty(state))
            {
                whereStr += $" and Visit_State='{state}'";
            }
            //按时间范围查询
            if (dateTimestr != null)
            {
                DateTime start = Convert.ToDateTime(dateTimestr.Substring(0, 10));
                DateTime end = Convert.ToDateTime(dateTimestr.Substring(13, 10));
                whereStr += $" and Plan_Time between '{start}' and '{end}'";
            }
            //获取销售管理的列表和条数
            ProcDataAndTotal<Base_Sale_Manager> saleList = _Salebll.ProcSale(whereStr, Page, limit);
            //循环List
            foreach (var item in saleList.ProcData)
            {
                //计算两个时间差的值
                TimeSpan timeSpan = Convert.ToDateTime(item.End_Date).Subtract(Convert.ToDateTime(item.Plan_Time));
                //计算时长
                item.TimeLenght = (timeSpan.Hours + (timeSpan.Days * 24)) + "小时" + timeSpan.Minutes + "分钟";
                //拼接拜访名称
                item.Visit_Name = item.Customer_Name + "-" + Convert.ToDateTime(item.Plan_Time).ToString("yyyyMMdd");
                //转换计划时间的格式
                item.Plan_Time = Convert.ToDateTime(item.Plan_Time).ToString("yyyy-MM-dd");
                //转换结束时间的格式
                item.End_Date = Convert.ToDateTime(item.End_Date).ToString("yyyy-MM-dd HH:mm:ss");
            }
            //返回Layui的字符串格式
            string str = "{\"code\": " + 0 + ",\"msg\": \"\",\"count\":" + saleList.Total + ",\"data\":" + JsonConvert.SerializeObject(saleList.ProcData) + "}";
            return str;
        }
        /// <summary>
        /// 查看拜访详情
        /// </summary>
        /// <param name="Sale_ID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Detail")]
        public Base_Sale_Manager Detail(Guid Sale_ID)
        {
            ProcDataAndTotal<Base_Sale_Manager> saleList = _Salebll.ProcSale("", 1, 1000);
            Base_Sale_Manager base_Sale = saleList.ProcData.Where(s => s.Sale_ID == Sale_ID).FirstOrDefault();
            return base_Sale;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        public int Delete(Guid Sale_ID)
        {
            int code = _Salebll.Delete(Sale_ID);
            if (code > 0)
            {
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 获取客户表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomer")]
        public List<Base_Customer_Profile> GetCustomer()
        {
            return _Salebll.GetCustomer();
        }
        /// <summary>
        /// 获取商机表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDeal")]
        public List<Base_Deal_Manager> GetDeal()
        {
            return _Salebll.GetDeal();
        }
        /// <summary>
        /// 新增销售管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertSale")]
        public int InsertSale([FromForm]Base_Sale_Manager model)
        {
            model.Visit_State = "未完成";
            model.End_Date = Convert.ToDateTime(DateTime.Now).ToString();
            int code = _Salebll.InsertSale(model);
            if(code > 0)
            {
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 外勤签到管理
        /// </summary>
        /// <param name="WhereStr"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetWaiQin")]
        public string GetWaiQin(int Page,int limit,string dateTimestr,string emp_Name,string emp_Dept)
        {
            string whereStr = "";
            if(!string.IsNullOrEmpty(emp_Name))
            {
                whereStr += $" and Emp_Name='{emp_Name}'";
            }
            if(!string.IsNullOrEmpty(emp_Dept))
            {
                whereStr += $" and Emp_Dept='{emp_Dept}'";
            }
            if (dateTimestr != null)
            {
                DateTime start = Convert.ToDateTime(dateTimestr.Substring(0,10));
                DateTime end = Convert.ToDateTime(dateTimestr.Substring(13,10));
                whereStr += $" and QianDate between '{start}' and '{end}'";
            }
            ProcDataAndTotal<WaiQinViewModel> WaiQinList = _Salebll.GetWaiQin(whereStr, Page, limit);
            string str = "{\"code\": " + 0 + ",\"msg\": \"\",\"count\":" + WaiQinList.Total + ",\"data\":" + JsonConvert.SerializeObject(WaiQinList.ProcData) + "}";
            return str;
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmps")]
        public List<Base_Emp_Information> GetEmps()
        {
            return _Salebll.GetEmps();
        }
        /// <summary>
        /// 拜访记录
        /// </summary>
        /// <param name="WhereStr"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVisit")]
        public string GetVisit(int Page,int limit,string keHu_Name,string fuZeRen)
        {
            string whereStr = "";
            if(!string.IsNullOrEmpty(keHu_Name))
            {
                whereStr += $" and Customer_Name like '%{keHu_Name}%'";
            }
            if(!string.IsNullOrEmpty(fuZeRen))
            {
                whereStr += $" and Responsible_Name like '%{fuZeRen}%'";
            }
            ProcDataAndTotal<VisitViewModel> vList = _Salebll.GetVisit(whereStr, Page, limit);
            string str = "{\"code\": " + 0 + ",\"msg\": \"\",\"count\":" + vList.Total + ",\"data\":" + JsonConvert.SerializeObject(vList.ProcData) + "}";
            return str;
        }
        /// <summary>
        /// 添加外勤签到信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertQianDao")]
        public int InsertQianDao([FromForm]Base_WaiQin model)
        {
            model.QianDate = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
            int code = _Salebll.InsertQianDao(model);
            if(code > 0)
            {
                if(Convert.ToDateTime(model.QianDate) > DateTime.Now)
                {
                    return -1;
                }
                return 1;
            }
            return 0;
        }
    }
}