using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	 public class Base_Emp_ExpreienceModel
	 {
		 public Guid  Expreience_ID { get; set; }
		 public Guid  Emp_ID { get; set; }
		 public string  Start_Time { get; set; }
		 public string  End_Time { get; set; }
		 public string  Education { get; set; }
		 public string  Academic_Degree { get; set; }
		 public string  Major { get; set; }
		 public string  Witness { get; set; }
		 public string  Witness_Phone { get; set; }
		 public string  School { get; set; }
		 public string  Awards { get; set; }
		 public string  Remarks { get; set; }
	 }
}
