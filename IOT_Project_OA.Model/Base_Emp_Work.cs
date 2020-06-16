using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	 public class Base_Emp_Work
	 {
		 public Guid  Work_ID { get; set; }
		 public Guid  Emp_ID { get; set; }
		 public string  Start_Time { get; set; }
		 public string  End_Time { get; set; }
		 public string  Work_Unit { get; set; }
		 public string  Work_Dept { get; set; }
		 public string  Work_Post { get; set; }
		 public string  Witness { get; set; }
		 public string  Witness_Phone { get; set; }
		 public decimal  Salary { get; set; }
		 public string  Resignation_Reson { get; set; }
		 public string  Remarks { get; set; }
	 }
}
