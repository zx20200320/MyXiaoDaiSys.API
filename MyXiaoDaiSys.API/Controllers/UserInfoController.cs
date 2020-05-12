using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyXiaoDaiSys.Bll;
using MyXiaoDaiSys.Model;
using MyXiaoDaiSys.API.Models;

namespace MyXiaoDaiSys.API.Controllers
{
    public class UserInfoController : ApiController
    {
        public UserInfoBll bll = new UserInfoBll();
        [HttpGet]
        public ApiResult<string> Login(string name, string pass)
        {
            ApiResult<string> result = new ApiResult<string>();

            UserInfo user =  bll.Login(name, pass); // 登陆
            
            if (user != null)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();// 创建内容
                dic.Add("Id", user.Id);
                dic.Add("Name", user.Name);
                dic.Add("Url", user.Url);

                JWTHelper helper = new JWTHelper();
                string token = helper.GetToken(dic, 1200);// 获取令牌

                result.Code = 0;
                result.Msg = "成功";
                result.Result = token;
            } 
            else 
            {
                result.Code = 1;
                result.Msg = "用户名或密码错误";
            }
            return result;
            

        }

        public string GetUrl(string Name)
        {
            return bll.GetUrl(Name);
        }
    }
}
