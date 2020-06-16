using System;
using System.Collections.Generic;
using System.Text;

namespace IOT_Project_OA.Model
{
    /// <summary>
    /// 权限管理表实体
    /// </summary>
    public class Base_jurisdiction
    {
        // 组织架构ID 
        public Guid J_ID { get; set; }
        // 登录名 
        public string Login_Name { get; set; }
        // 登录用户名 
        public string Login_Pwd { get; set; }
        // 姓名 
        public string User_Name { get; set; }
        // 部门名称 
        public string Dept_Name { get; set; }
        // 岗位 
        public string Dept_Post { get; set; }
        //手机号
        public string Phone { get; set; }

    }
}
