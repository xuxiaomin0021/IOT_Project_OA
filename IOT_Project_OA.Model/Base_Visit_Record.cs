using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    /// <summary>
    /// 拜访记录表
    /// </summary>
    public class Base_Visit_Record
    {
        //拜访记录ID
        public Guid Record_ID { get; set; }
        //客户档案ID
        public Guid Customer_ID { get; set; }
        //外勤签到次数
        public int Wai_Count { get; set; }
        //总拜访次数
        public int All_Count { get; set; }
        //距离异常次数
        public int Abnormal_Count { get; set; }
    }
}
