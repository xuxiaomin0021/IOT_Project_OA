using IOT_Project_OA.DAL;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IOT_Project_OA.BLL.IBLL.SaleIBLL
{
    public interface SaleaAdminIBLL
    {
        /// <summary>
        /// 显示存储过程分页 销售管理
        /// </summary>
        /// <param name="WhereStr">查询条件</param>
        /// <param name="PageIndex">页数</param>
        /// <param name="PageSize">页码</param>
        /// <param name="Total">总数</param>
        /// <returns></returns>
        public ProcDataAndTotal<Base_Sale_Manager> ProcSale(string WhereStr, int PageIndex, int PageSize);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Sale_ID"></param>
        /// <returns></returns>
        public int Delete(Guid Sale_ID);
        /// <summary>
        /// 获取客户表
        /// </summary>
        /// <returns></returns>
        public List<Base_Customer_Profile> GetCustomer();
        /// <summary>
        /// 获取商机表
        /// </summary>
        /// <returns></returns>
        public List<Base_Deal_Manager> GetDeal();
        /// <summary>
        /// 新增拜访信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertSale(Base_Sale_Manager model);
        /// <summary>
        /// 外勤签到管理
        /// </summary>
        /// <param name="WhereStr"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public ProcDataAndTotal<WaiQinViewModel> GetWaiQin(string WhereStr, int PageIndex, int PageSize);
        /// <summary>
        /// 获取员工所有信息
        /// </summary>
        /// <returns></returns>
        public List<Base_Emp_Information> GetEmps();
        /// <summary>
        /// 拜访记录
        /// </summary>
        /// <param name="WhereStr"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public ProcDataAndTotal<VisitViewModel> GetVisit(string WhereStr, int PageIndex, int PageSize);
        /// <summary>
        /// 添加外勤签到
        /// </summary>
        /// <returns></returns>
        public int InsertQianDao(Base_WaiQin model);
    }
}
