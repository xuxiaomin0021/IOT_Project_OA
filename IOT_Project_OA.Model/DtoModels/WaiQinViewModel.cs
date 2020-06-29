using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    public class WaiQinViewModel
    {
        public Guid ID { get; set; }
        public Guid Emp_ID { get; set; }
        public Guid Customer_ID { get; set; }
        public string QianDate { get; set; }
        public string QianAddress { get; set; }
        public string QianDistince { get; set; }
        public string Emp_Dept { get; set; }
        public string Emp_Name { get; set; }
        public string Customer_Name { get; set; }
    }
}
