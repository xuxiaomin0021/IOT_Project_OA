using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOT_Project_OA.Model
{
    /// <summary>
    /// 权限及菜单表
    /// </summary>
    public class Base_Quan
    {
        public int ID { get; set; }
        public string Menu_Name { get; set; }
        public int UP_ID { get; set; }
        public string Menu_Url { get; set; }

    }
}
