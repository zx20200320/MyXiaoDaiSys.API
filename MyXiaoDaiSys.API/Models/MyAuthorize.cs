using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using Newtonsoft.Json;
using MyXiaoDaiSys.Model;

namespace MyXiaoDaiSys.API.Models
{
    public class MyAuthorize:AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                // 获取用户身份 ，验证身份
                string Auth = actionContext.Request.Headers.GetValues("MyAuth").FirstOrDefault();
                if (Auth != null) // 身份不为空
                {
                    string userinfo = new JWTHelper().GetPayload(Auth);
                    if (userinfo != null)//身份合法
                    {
                        Console.WriteLine("身份合法，继续访问");
                    }
                    else
                    {
                        actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                        var x = new ApiResult<string>() { Code = 1, Msg = "身份信息不合法，请重新登陆" };
                        actionContext.Response.Content = new StringContent(JsonConvert.SerializeObject(x), System.Text.Encoding.UTF8, "application/json");
                    }

                }   // 身份不合法，拒绝访问
                else
                {
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                    var x = new ApiResult<string>() { Code = 1, Msg = "缺少验证信息，请重新登陆" };
                    actionContext.Response.Content = new StringContent(JsonConvert.SerializeObject(x), System.Text.Encoding.UTF8, "application/json");
                }
            }
            catch {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                var x = new ApiResult<string>() { Code = 1, Msg = "缺少验证信息，请重新登陆" };
                actionContext.Response.Content = new StringContent(JsonConvert.SerializeObject(x), System.Text.Encoding.UTF8, "application/json");
            }
        }
    }
}