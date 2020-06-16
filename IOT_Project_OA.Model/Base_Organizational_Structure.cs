using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	 public class Base_Organizational_Structure
	 {
		 public Guid  O_ID { get; set; }
		 public string  Superior_Deptment { get; set; }
		 public string  Dept_Name { get; set; }
		 public int  Dept_No { get; set; }
		 public string  Dept_Director { get; set; }
		 public int  PhoneNumber { get; set; }
		 public string  DEmail { get; set; }
		 public int  Fax { get; set; }
		 public string  Remarks { get; set; }
	 }
}
