using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    public class SaleViewModel
    {
        public Guid Sale_ID { get; set; }
        public Guid Business_ID { get; set; }
        public Guid Customer_ID { get; set; }
        public string Visit_Type { get; set; }
        public string Plan_Time { get; set; }
        public string Sale_Desc { get; set; }
        public string Visit_State { get; set; }
        public string End_Date { get; set; }
        public string Customer_Name { get; set; }
        public string Responsible_Name { get; set; }
        public string TimeLenght { get; set; }
        public string Visit_Name { get; set; }
        public string Contact_Name { get; set; }
        public string Agent_Name { get; set; }
    }
}
