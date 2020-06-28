using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_Project_OA.BLL;
using IOT_Project_OA.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IOT_Project_OA.API.Controllers.Emp
{
    /// <summary>
    /// 用于用户祖册后的角色，权限的分配
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyCores")]
    public class ToAllocateController : ControllerBase
    {
        private IRegisterBLL bll;
        public ToAllocateController(IRegisterBLL _bll)
        {
            bll = _bll;
        }


        /// <summary>
        /// 角色表添加,角色权限表添加 同时添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int RegisterRole([FromForm]RegisterRoleAndQuan model)
        {
            string time = DateTime.Now.ToString();
            //分割获取到的权限ID，分为数组类型
            var ids = model.Q_ids.Split(',');
            //实例化初始化器赋值
            Base_Role role = new Base_Role() { Role_Name = model.Role_Name, Role_Desc = model.Role_Desc,CreateDate = time };
            //添加角色,接收受影响行数
            int flag = bll.AddRole(role);
            //判断是否添加成功
            if(flag < 0)
            {
                return 0;
            }
            //获取所有的角色
            List<Base_Role> list = bll.GetRoleList();
            //通过时间判断刚才所添加的角色ID
            Base_Role rmodel = list.Where(s => s.CreateDate.Equals(time)).FirstOrDefault();
            //赋值
            int code = rmodel.ID;
            //循环添加角色权限表
            for (int i = 0; i < ids.Length; i++)
            {
                flag += bll.AddRoleAndQuan(int.Parse(ids[i]),code);
            }
            //返回受影响行数
            return flag;
        }


        /// <summary>
        /// 显示可访问的权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Base_Quan> ShowQuan()
        {
            return bll.Select(); 
        }


        [HttpGet]
        public List<Base_Role> GetRoleList()
        {
            List<Base_Role> list = bll.GetRoleList();
            return list;
        }

        [HttpPost]
        public int AddUserAndRole([FromForm]AddUserAndRole model)
        {
            Base_User user =  bll.GetUserList().Where(s=>s.User_Name.Equals(model.User_Name)).FirstOrDefault();
            if(user == null)
            {
                return 0;
            }
            Base_RoleAndUser m = new Base_RoleAndUser() {
                Role_ID = model.Role_ID,
                User_ID = user.User_ID
            };
            return bll.AddUserAndRole(m);
        }

        /// <summary>
        /// 获取数据库中角色和权限的四个属性
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<ShowRoleAndQuan>> GetShowList(string role_Name = "")
        {
            List<Base_Role> rList = await Task.Run(() => { return bll.GetRoleList(); });
            List<Base_Quan> qList = await Task.Run(() => { return bll.GetQuanList(); });
            List<Base_QuanAndRole> qrList = await Task.Run(() => { return bll.GetQandRList(); });
            
            List<ShowRoleAndQuan> list = new List<ShowRoleAndQuan>();
            list = (from r in rList
                   join qr in qrList on r.ID equals qr.Role_ID
                   join q in qList on qr.Quan_ID equals q.ID
                   select new ShowRoleAndQuan
                    {
                        CreateDate = r.CreateDate,
                        Role_Desc = r.Role_Desc,
                        Role_Name = r.Role_Name,
                        Menu_Name =q.Menu_Name
                   }).ToList();
            if (!string.IsNullOrEmpty(role_Name))
            {
                list = list.Where(s => s.Role_Name.Equals(role_Name)).ToList();
            }

            return list;
        }



    }
}
