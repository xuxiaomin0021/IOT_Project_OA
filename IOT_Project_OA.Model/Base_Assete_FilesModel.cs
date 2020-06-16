using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	 public class Base_Assete_FilesModel
	 {
		 public Guid  Assets_ID { get; set; }
		 public int  Assets_No { get; set; }
		 public string  Assets_Class { get; set; }
		 public string  Assets_Type { get; set; }
		 public int  Assets_Number { get; set; }
		 public string  Assets_Unit { get; set; }
		 public string  Emtry_Time { get; set; }
		 public string  Emtry_Name { get; set; }
		 public string  Use_Time { get; set; }
		 public int  Use_Years { get; set; }
		 public string  Expire_Time { get; set; }
		 public string  Assets_Desc { get; set; }
		 public decimal  Bill_Money { get; set; }
		 public string  Bill_Time { get; set; }
	 }
}
