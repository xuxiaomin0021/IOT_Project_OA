using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    /// <summary>
    /// 资产分类
    /// </summary>
    public class Assets_Class
    {
       public int  Asset_TypeID     {get;set; }//资产分类ID
        public string Class_Name       {get;set; }//分类名称
        public string Up_Class_Name    {get;set; }//上级分类名称
        public string Remarks          {get;set; }//备注
        public string Filed_Name       {get;set; }//字段名称
    }
}
