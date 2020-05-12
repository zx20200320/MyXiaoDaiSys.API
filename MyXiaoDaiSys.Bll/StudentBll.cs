using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyXiaoDaiSys.Model;
using MyXiaoDaiSys.Dal;
namespace MyXiaoDaiSys.Bll
{
    public class StudentBll
    {
        StudentDal dal = new StudentDal();
        public int Add(Student s)
        {
            return dal.AddStu(s);
        }
        public PageData<Student> GetData(string Name, string Tel, int PageIndex, int PageSize)
        {
            return dal.GetData(Name, Tel, PageIndex, PageSize);
        }
    }
}
