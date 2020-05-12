using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyXiaoDaiSys.Model;
using MyXiaoDaiSys.Dal;

namespace MyXiaoDaiSys.Bll
{
    public class UserInfoBll
    {
        public UserInfo Login(string Name, string pass)
        {
            return new UserInfoDal().Login(Name, pass);
        }

        public string GetUrl(string Name)
        {
           
            return new UserInfoDal().GetUrl(Name);
        }
    }
}
