using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    /// <summary>
    /// 角色管理表实体
    /// </summary>
    public class Base_Role
    {
        //角色id
        public Guid Role_ID { get; set; }
        //角色名称
        public string Role_Name { get; set; }
        //角色描述
        public string Role_Desc { get; set; }

    }
}
