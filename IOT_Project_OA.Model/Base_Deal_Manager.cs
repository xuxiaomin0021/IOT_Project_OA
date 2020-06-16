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
		 public Guid  Customer_ID { get; set; }//�ͻ�id
		public string Customer_Name { get; set; }//�ͻ�����
		public string Responsible_Name { get; set; }//�̻�����
		public string Contact_Name { get; set; } //�ͻ���ϵ������
		public string  Deal_Time { get; set; }//Ԥ�Ƴɽ�����
		public string  Find_Time { get; set; }//�̻���������
		public string  Deal_Desc { get; set; }//����
		public string  Deal_Source { get; set; }//�̻���Դ
		public string  Agent_Name { get; set; }//�ͻ�����������
		public decimal  Deal_Money { get; set; }//�̻����
		public string  Purchase_Time { get; set; }//�ɹ�ʱ��
		public string  Purchase_Level { get; set; }//�ɹ�����
		public string  Purchase_Way { get; set; }//�ɹ���ʽ
		public string  Purchase_Channel { get; set; }//�ɹ�;��
		public string  Distribution { get; set; }//�������
		public string  Follow_State { get; set; }//����״̬
		public string  Stage_State { get; set; }//�׶�״̬
		public string  Remarks { get; set; }//��ע��Ϣ
	}
}
