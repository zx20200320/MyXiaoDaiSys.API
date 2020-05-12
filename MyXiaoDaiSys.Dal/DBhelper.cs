using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace MyXiaoDaiSys.Dal
{
    public static  class DBhelper<T> where T:class, new()
    {
        private static string constr = @"server=30YU1CEWFS3390J\SQLEXPRESS;uid=sa;pwd=1234;database=MyMoniWeek1";
        private static int ExecuteSqlCommand(string sql) // 执行 增删改
        {
            using (SqlConnection scon = new SqlConnection(constr)) {
                scon.Open();
                SqlCommand scom = new SqlCommand(sql, scon);
                return scom.ExecuteNonQuery();
            }
        }

        private static DataTable ExecuteTable(string sql)
        {
            using (SqlConnection scon = new SqlConnection(constr))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sada = new SqlDataAdapter(sql, scon);
                sada.Fill(dt);
                return dt;
            }
        }

        public static int Add(T t) 
        {
            var type = t.GetType();
            var tableName = type.Name;
            var colNames = string.Join(",", type.GetProperties().Where(p => p.Name.ToLower() != "id").Select(p => p.Name).ToList());
            var colVals = string.Join(",", type.GetProperties().Where(p => p.Name.ToLower() != "id").Select(p => "'" + p.GetValue(t) + "'"));

            string sql = $"insert into {tableName}  ( {colNames} ) values ( {colVals})";
            return ExecuteSqlCommand(sql);
        }

        public static int Update(int Id,T t)
        {
            var type = t.GetType();
            var tableName = type.Name;
            var colNames = string.Join(
                ",", 
                type.GetProperties().Where(p => p.Name.ToLower() != "id").Select(p => p.Name +"='"+p.GetValue(t)+"'" ).ToList());
           

            string sql = $"update {tableName} set  {colNames}  where Id = {Id}";
            return ExecuteSqlCommand(sql);
        }

        public static int Delete(int Id)
        {
            var type = typeof(T);
            var tableName = type.Name;
            string sql = $"delete from {tableName} where Id={Id}";
            return ExecuteSqlCommand(sql);
        }

        public static List<T> GetAll()
        {
            var type = typeof(T);
            var tableName = type.Name;
            string sql = $"select * from {tableName}";
            var dt = ExecuteTable(sql);
            return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(dt));
        }

        public static List<T> GetData(string sql)
        {
            var dt = ExecuteTable(sql);
            return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(dt));
        }
    }
}
