using IOT_Project_OA.BLL.IBLL.SaleIBLL;
using IOT_Project_OA.DAL;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using IOT_Project_OA.DAL.IDAL;
using IOT_Project_OA.DAL.IDAL.SaleIDAL;

namespace IOT_Project_OA.BLL.BLL.SaleBLL
{
    public class SaleaAdminBLL : SaleaAdminIBLL
    {
        /// <summary>
        /// 依赖注入DAL
        /// </summary>
        public SaleaAdminIDAL _Saledal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Salebll"></param>
        public SaleaAdminBLL(SaleaAdminIDAL Saledal)
        {
            _Saledal = Saledal;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Sale_ID"></param>
        /// <returns></returns>
        public int Delete(Guid Sale_ID)
        {
            return _Saledal.Delete(Sale_ID);
        }
        /// <summary>
        /// 获取客户表
        /// </summary>
        /// <returns></returns>
        public List<Base_Customer_Profile> GetCustomer()
        {
            return _Saledal.GetCustomer();
        }
        /// <summary>
        /// 获取商机表
        /// </summary>
        /// <returns></returns>
        public List<Base_Deal_Manager> GetDeal()
        {
            return _Saledal.GetDeal();
        }
        /// <summary>
        /// 获取所有员工信息
        /// </summary>
        /// <returns></returns>
        public List<Base_Emp_Information> GetEmps()
        {
            return _Saledal.GetEmps();
        }
        /// <summary>
        /// 拜访记录
        /// </summary>
        /// <param name="WhereStr"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public ProcDataAndTotal<VisitViewModel> GetVisit(string WhereStr, int PageIndex, int PageSize)
        {
            return _Saledal.GetVisit(WhereStr, PageIndex, PageSize);
        }

        /// <summary>
        /// 外勤签到管理
        /// </summary>
        /// <param name="WhereStr"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public ProcDataAndTotal<WaiQinViewModel> GetWaiQin(string WhereStr, int PageIndex, int PageSize)
        {
            return _Saledal.GetWaiQin(WhereStr, PageIndex, PageSize);
        }
        /// <summary>
        /// 添加外勤签到信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertQianDao(Base_WaiQin model)
        {
            int code = _Saledal.InsertQianDao(model);
            return code;
        }

        /// <summary>
        /// 新增拜访信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertSale(Base_Sale_Manager model)
        {
            int code = _Saledal.InsertSale(model);
            return code;
        }

        /// <summary>
        /// 显示销售管理存储过程分页
        /// </summary>
        /// <param name="WhereStr">查询的条件</param>
        /// <param name="PageIndex">页数</param>
        /// <param name="PageSize">页码</param>
        /// <returns></returns>
        public ProcDataAndTotal<Base_Sale_Manager> ProcSale(string WhereStr, int PageIndex, int PageSize)
        {
            return _Saledal.ProcSale(WhereStr,PageIndex,PageSize);
        }
    }
}
