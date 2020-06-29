using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_Project_OA.BLL;
using IOT_Project_OA.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOT_Project_OA.API.Controllers.DeskShow
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DeskController : ControllerBase
    {
        private IRegisterBLL bll;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="_bll"></param>
        public DeskController(IRegisterBLL _bll)
        {
            bll = _bll;
        }


        /// <summary>
        /// 获取动态菜单
        /// </summary>
        /// <param name="upID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Base_Quan>> GetQuan(int upID = 0) 
        {
            List<Base_Quan> list = await Task.Run(() => { return bll.GetQuanList(); });
            list = list.Where(s => s.UP_ID == upID).ToList();
            return list;
        }


    }
}
