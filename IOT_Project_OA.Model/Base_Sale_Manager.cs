using System;

namespace IOT_Project_OA.Model
{
    /// <summary>
    /// 销售管理表
    /// </summary>
    public class Base_Sale_Manager
    {
        //销售管理ID
        public Guid Sale_ID { get; set; }
        //商机管理ID
        public Guid Business_ID { get; set; }
        //客户档案ID
        public Guid Customer_ID { get; set; }
        //拜访类型
        public string Visit_Type { get; set; }
        //计划时间
        public string Plan_Time { get; set; }
        //销售描述
        public string Sale_Desc { get; set; }
        //客户名称
        public string Customer_Name { get; set; }
    }
}
