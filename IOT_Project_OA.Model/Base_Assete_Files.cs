using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	 public class Base_Assete_Files
	 {
		//资产档案ID
		 public Guid  Assets_ID { get; set; }
		//编号
		 public int  Assets_No { get; set; }
		//资产分类
		 public string  Assets_Class { get; set; }
		//资产类型
		 public string  Assets_Type { get; set; }
		//资产数量
		 public int  Assets_Number { get; set; }
		//资产单位
		 public string  Assets_Unit { get; set; }
		//资产录入日期
		 public string  Emtry_Time { get; set; }
		//录入人姓名
		 public string  Emtry_Name { get; set; }
		//使用日期
		 public string  Use_Time { get; set; }
		//使用年限
		 public int  Use_Years { get; set; }
		//到期时间
		 public string  Expire_Time { get; set; }
		//资产描述
		 public string  Assets_Desc { get; set; }
		//发票金额
		 public decimal  Bill_Money { get; set; }
		//发票日期
		 public string  Bill_Time { get; set; }
	 }
}
