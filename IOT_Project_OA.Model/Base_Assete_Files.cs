using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
	 public class Base_Assete_Files
	 {
		//�ʲ�����ID
		 public Guid  Assets_ID { get; set; }
		//���
		 public int  Assets_No { get; set; }
		//�ʲ�����
		 public string  Assets_Class { get; set; }
		//�ʲ�����
		 public string  Assets_Type { get; set; }
		//�ʲ�����
		 public int  Assets_Number { get; set; }
		//�ʲ���λ
		 public string  Assets_Unit { get; set; }
		//�ʲ�¼������
		 public string  Emtry_Time { get; set; }
		//¼��������
		 public string  Emtry_Name { get; set; }
		//ʹ������
		 public string  Use_Time { get; set; }
		//ʹ������
		 public int  Use_Years { get; set; }
		//����ʱ��
		 public string  Expire_Time { get; set; }
		//�ʲ�����
		 public string  Assets_Desc { get; set; }
		//��Ʊ���
		 public decimal  Bill_Money { get; set; }
		//��Ʊ����
		 public string  Bill_Time { get; set; }
	 }
}
