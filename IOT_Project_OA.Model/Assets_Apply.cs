using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	 public class Assets_Apply
	{
		 public Guid  Apply_ID { get; set; }
		 public string  Apply_Name { get; set; }
		 public string  Apply_Depart { get; set; }
		 public string  Apply_Time { get; set; }
		 public string  Bill_No { get; set; }
		 public string  Importance_Level { get; set; }
		 public string  Apply_Reson { get; set; }
		 public string  Scale { get; set; }
		 public string  Company { get; set; }
		 public int  Number { get; set; }
		 public decimal  Price { get; set; }
		 public decimal  Subtotal { get; set; }
		 public string  Suggest_Time { get; set; }
	 }
}
