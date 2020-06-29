using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    public class Base_WaiQin
    {
        public Guid ID { get; set; }
        public Guid Emp_ID { get; set; }
        public Guid Customer_ID { get; set; }
        public string QianDate { get; set; }
        public string QianAddress { get; set; }
        public string QianDistince { get; set; }
        public Guid QianDao_ID { get; set; }
    }
}
