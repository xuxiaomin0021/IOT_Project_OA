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
		 public Guid  Customer_ID { get; set; }//客户id
		public string Customer_Name { get; set; }//客户名称
		public string Responsible_Name { get; set; }//商机名称
		public string Contact_Name { get; set; } //客户联系人姓名
		public string  Deal_Time { get; set; }//预计成交日期
		public string  Find_Time { get; set; }//商机发现日期
		public string  Deal_Desc { get; set; }//描述
		public string  Deal_Source { get; set; }//商机来源
		public string  Agent_Name { get; set; }//客户经办人姓名
		public decimal  Deal_Money { get; set; }//商机金额
		public string  Purchase_Time { get; set; }//采购时间
		public string  Purchase_Level { get; set; }//采购级别
		public string  Purchase_Way { get; set; }//采购方式
		public string  Purchase_Channel { get; set; }//采购途径
		public string  Distribution { get; set; }//分配情况
		public string  Follow_State { get; set; }//跟进状态
		public string  Stage_State { get; set; }//阶段状态
		public string  Remarks { get; set; }//备注信息
	}
}
