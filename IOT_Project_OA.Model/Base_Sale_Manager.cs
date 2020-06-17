using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
    public class Base_Sale_Manager
    {
        public Guid Sale_ID { get; set; }
        public Guid Business_ID { get; set; }
        public Guid Customer_ID { get; set; }
        public string Visit_Type { get; set; }
        public string Plan_Time { get; set; }
        public string Sale_Desc { get; set; }
        public string Visit_State { get; set; }
        public string End_Date { get; set; }
    }
}
