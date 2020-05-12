using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyXiaoDaiSys.Model;

namespace MyXiaoDaiSys.Dal
{
    public class StudentDal
    {
        // 添加方法
        public int AddStu(Student s)
        {
            return DBhelper<Student>.Add(s);
        }
        // 分页条件查询
        public PageData<Student> GetData(string Name, string Tel, int PageIndex = 1, int PageSize = 3)
        {
            PageData<Student> pd = new PageData<Student>();
            pd.PageSize = PageSize;


            int start = (PageIndex - 1) * PageSize + 1;
            int end = PageIndex * PageSize;
            string sql = "from Student where 1=1 ";
            
            if (!string.IsNullOrWhiteSpace(Name))
                sql += $" and Name like '%{Name}%'";

            if (!string.IsNullOrWhiteSpace(Tel))
                sql += $" and Tel like '%{Tel}%'";
            


           
            // SQL 设置好查询条件 获取总记录数 ，，
            pd.TotalRecord = DBhelper<Student>.GetData("select * "+ sql).Count();

            // Sql 设置好分页，获取当前页记录
            var pageSql = "select * from ( select Row_number() over(order by Id) as No, * " +
                    sql +
                    $") T  where T.No between {start} and {end}";

            pd.Data = DBhelper<Student>.GetData(pageSql);

            return pd;
        }

    }
}
