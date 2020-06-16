using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	 public class Base_Deal_Manager
	 {
		 public Guid  Business_ID { get; set; }
		 public Guid  Customer_ID { get; set; }
		 public string  Responsible_Name { get; set; }
		 public string  Deal_Time { get; set; }
		 public string  Find_Time { get; set; }
		 public string  Deal_Desc { get; set; }
		 public string  Deal_Source { get; set; }
		 public string  Agent_Name { get; set; }
		 public decimal  Deal_Money { get; set; }
		 public string  Purchase_Time { get; set; }
		 public string  Purchase_Level { get; set; }
		 public string  Purchase_Way { get; set; }
		 public string  Purchase_Channel { get; set; }
		 public string  Distribution { get; set; }
		 public string  Follow_State { get; set; }
		 public string  Stage_State { get; set; }
		 public string  Remarks { get; set; }
	 }
}
