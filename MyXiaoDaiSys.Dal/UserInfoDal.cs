using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyXiaoDaiSys.Model;

namespace MyXiaoDaiSys.Dal
{
    public class UserInfoDal
    {
        public UserInfo Login(string Name, string Pass)
        {
            string sql = $"select * from UserInfo where Name='{Name}' and Pass = '{Pass}'";
            return DBhelper<UserInfo>.GetData(sql).FirstOrDefault();
        }

        public string GetUrl(string Name)
        {
            string sql = $"select * from UserInfo where Name='{Name}'";
            return DBhelper<UserInfo>.GetData(sql).FirstOrDefault()?.Url;
        }
    }
}
