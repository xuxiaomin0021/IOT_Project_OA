using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	//�ͻ�������
	public class Base_Customer_Profile
	 {
		 public Guid  Customer_ID { get; set; }
		 public string  Customer_Name { get; set; }//�ͻ�����
		public string  Customer_Address { get; set; }//��ϸ��ַ
		public string  Contact_Name { get; set; }//��ϵ������
		public string  Contact_Phone { get; set; }//��ϵ���ֻ���
		public string  Province { get; set; }//ʡ��
		public string  City { get; set; }//����
		public string  Area { get; set; }//����
		public string  Zip_Code { get; set; }//�ʱ�
		public string  Website { get; set; }//��վ
		public string  Industry_Type { get; set; }//��ҵ���
		public string  Customer_Level { get; set; }//�ͻ�����
		public string  Customer_Type { get; set; }//�ͻ�����
	}
}
