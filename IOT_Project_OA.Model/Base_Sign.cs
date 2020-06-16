using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    /// <summary>
    /// 外勤签到表
    /// </summary>
    public  class Base_Sign
    {
        //外勤签到ID
        public Guid Sign_ID { get; set; }
        //客户ID
        public Guid Customer_ID { get; set; }
        //备注
        public string Remarks { get; set; }
    }
}
