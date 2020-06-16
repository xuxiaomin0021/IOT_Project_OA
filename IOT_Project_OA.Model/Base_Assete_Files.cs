using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    /// <summary>
    /// 资产详情
    /// </summary>
    public class Base_Assete_Files
    {
        public Guid Assets_ID { get; set; }//资产档案ID
        public int Assets_No { get; set; }//资产编号
        public string Assets_Class { get; set; }//资产分类
        public string Assets_Type { get; set; }//资产类型
        public int Assets_Number { get; set; }//资产数量
        public string Assets_Unit { get; set; }//资产单位
        public string Emtry_Time { get; set; }//录入日期
        public string Emtry_Name { get; set; }//录入人姓名
        public string Use_Time { get; set; }//使用日期
        public int Use_Years { get; set; }//使用年限
        public string Expire_Time { get; set; }//到期时间
        public string Assets_Desc { get; set; }//资产描述
        public decimal Bill_Money { get; set; }//发票金额
        public string Bill_Time { get; set; }//发票日期
    }
}
