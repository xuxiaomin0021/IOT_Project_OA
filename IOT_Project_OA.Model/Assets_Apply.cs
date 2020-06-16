using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    /// <summary>
    /// 资产申请
    /// </summary>
    public class Assets_Apply
    {
        public Guid Apply_ID { get; set; }//资产申请ID
        public string Apply_Name { get; set; }//申请人
        public string Apply_Depart { get; set; }//申请部门
        public string Apply_Time { get; set; }//申请时间
        public string Bill_No { get; set; }//单据编号
        public string Importance_Level { get; set; }//重要等级
        public string Apply_Reson { get; set; }//申请原因
        public string Scale { get; set; }//规模型号
        public string Company { get; set; }//单位
        public int Number { get; set; }//数量
        public decimal Price { get; set; }//预计单价
        public decimal Subtotal { get; set; }//小计
        public string Suggest_Time { get; set; }//建议到货日期
    }
}
