using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	//客户档案表
	public class Base_Customer_Profile
	 {
		 public Guid  Customer_ID { get; set; }
		 public string  Customer_Name { get; set; }//客户名称
		public string  Customer_Address { get; set; }//详细地址
		public string  Contact_Name { get; set; }//联系人姓名
		public string  Contact_Phone { get; set; }//联系人手机号
		public string  Province { get; set; }//省份
		public string  City { get; set; }//市名
		public string  Area { get; set; }//区名
		public string  Zip_Code { get; set; }//邮编
		public string  Website { get; set; }//网站
		public string  Industry_Type { get; set; }//行业类别
		public string  Customer_Level { get; set; }//客户级别
		public string  Customer_Type { get; set; }//客户类型
	}
}
