using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	 public class Base_Customer_Profile
	 {
		 public Guid  Customer_ID { get; set; }
		 public string  Customer_Name { get; set; }
		 public string  Customer_Address { get; set; }
		 public string  Contact_Name { get; set; }
		 public string  Contact_Phone { get; set; }
		 public string  Province { get; set; }
		 public string  City { get; set; }
		 public string  Area { get; set; }
		 public string  Zip_Code { get; set; }
		 public string  Website { get; set; }
		 public string  Industry_Type { get; set; }
		 public string  Customer_Level { get; set; }
		 public string  Customer_Type { get; set; }
	 }
}
