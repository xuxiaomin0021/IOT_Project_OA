using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    /// <summary>
    /// 角色权限表实体
    /// </summary>
    public class Base_Role_JurQue
    {
        //角色权限ID
        public Guid ID { get; set; }
        //角色ID
        public Guid Role_ID { get; set; }
        //权限ID
        public Guid JueSe_ID { get; set; }

    }
}
