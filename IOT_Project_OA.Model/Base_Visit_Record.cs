using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
    public class Base_Visit_Record
    {
        public Guid Record_ID { get; set; }
        public Guid Customer_ID { get; set; }
        public int Wai_Count { get; set; }
        public int All_Count { get; set; }
        public int Abnormal_Count { get; set; }
        public Guid Business_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Responsible_Name { get; set; }
    }
}
