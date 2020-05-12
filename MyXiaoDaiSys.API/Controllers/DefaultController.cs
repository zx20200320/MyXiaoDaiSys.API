using System;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyXiaoDaiSys.API.Models;
using MyXiaoDaiSys.Model;

namespace MyXiaoDaiSys.API.Controllers
{
    public class DefaultController : ApiController
    {
       [MyAuthorize]
        [HttpGet]
        public ApiResult<int> Add(int i, int j)
        {
            ApiResult<int> result = new ApiResult<int>();
            try
            {
                int k = i / j;
                result.Code = 0;
                result.Msg = "成功";
                result.Result = k;
            }
            catch(Exception ex) {
                result.Code = 1;
                result.Msg = ex.Message;
                result.Result = 0;
            }

            return result;
        }
    }
}
