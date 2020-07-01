using Dapper;
using IOT_Project_OA.DAL.IDAL.SaleIDAL;
using IOT_Project_OA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IOT_Project_OA.DAL.DAL.SaleDAL
{
    public class SaleaAdminDAL : SaleaAdminIDAL
    {
        //实例化Dapper
        DapperHelper helper = new DapperHelper();
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Sale_ID"></param>
        /// <returns></returns>
        public int Delete(Guid Sale_ID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Sale_ID",Sale_ID);
            return helper.ProcExec<Base_Sale_Manager>(parameters, "Delete_Sale");
        }
        /// <summary>
        /// 获取客户表
        /// </summary>
        /// <returns></returns>
        public List<Base_Customer_Profile> GetCustomer()
        {
            List<Base_Customer_Profile> cList = helper.GetToList<Base_Customer_Profile>();
            return cList;
        }
        /// <summary>
        /// 获取商机表
        /// </summary>
        /// <returns></returns>
        public List<Base_Deal_Manager> GetDeal()
        {
            List<Base_Deal_Manager> dList = helper.GetToList<Base_Deal_Manager>();
            return dList;
        }
        /// <summary>
        /// 获取员工所有信息
        /// </summary>
        /// <returns></returns>
        public List<Base_Emp_Information> GetEmps()
        {
            List<Base_Emp_Information> eList = helper.GetToList<Base_Emp_Information>();
            return eList;
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
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@WhereStr", WhereStr);
            parameters.Add("@PageIndex", PageIndex);
            parameters.Add("@PageSize", PageSize);
            parameters.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);
            return helper.GetProcData<WaiQinViewModel>(parameters, "SP_WaiQin");
        }

        /// <summary>
        /// 新增拜访信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertSale(Base_Sale_Manager model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Business_ID",model.Business_ID);
            parameters.Add("@Customer_ID",model.Customer_ID);
            parameters.Add("@Visit_Type",model.Visit_Type);
            parameters.Add("@@Plian_Time",model.Plan_Time);
            parameters.Add("@Sale_Desc",model.Sale_Desc);
            parameters.Add("@Visit_State",model.Visit_State);
            parameters.Add("@End_Date",model.End_Date);
            return helper.ProcExec<Base_Sale_Manager>(parameters, "Insert_Sale");
        }
        /// <summary>
        /// 销售管理
        /// </summary>
        /// <param name="WhereStr"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public ProcDataAndTotal<Base_Sale_Manager> ProcSale(string WhereStr, int PageIndex, int PageSize)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@WhereStr",WhereStr);
            parameters.Add("@PageIndex", PageIndex);
            parameters.Add("@PageSize", PageSize);
            parameters.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);
            return helper.GetProcData<Base_Sale_Manager>(parameters, "SP_Sale");
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
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@WhereStr", WhereStr);
            parameters.Add("@PageIndex", PageIndex);
            parameters.Add("@PageSize", PageSize);
            parameters.Add("@Total", 0, DbType.Int32, ParameterDirection.Output);
            return helper.GetProcData<VisitViewModel>(parameters, "SP_Visit");
        }
        /// <summary>
        /// 添加外勤签到信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertQianDao(Base_WaiQin model)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Emp_ID", model.Emp_ID);
            parameters.Add("@Customer_ID", model.Customer_ID);
            parameters.Add("@QianDate", model.QianDate);
            parameters.Add("@QianAddress", model.QianAddress);
            parameters.Add("@QianDistince", model.QianDistince);
            return helper.ProcExec<Base_WaiQin>(parameters, "SP_QianDao");
        }
    }
}