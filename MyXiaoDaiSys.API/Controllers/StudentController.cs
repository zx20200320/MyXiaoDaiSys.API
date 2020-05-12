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
    [MyAuthorize]
    public class StudentController : ApiController
    {
        StudentBll bll = new StudentBll();
        public int Post(Student s)
        {
            return bll.Add(s);
        }
        [HttpGet]
        public ApiResult<PageData<Student>> GetPage( int pageIndex=1, int pageSize=3, string name = "", string tel = "")
        {
            var data =  bll.GetData(name, tel, pageIndex, pageSize);
            ApiResult<PageData<Student>> result = new ApiResult<PageData<Student>>();
            result.Code = 0;
            result.Result = data;
            return result;
        }
    }
}
