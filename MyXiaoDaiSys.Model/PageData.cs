using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXiaoDaiSys.Model
{
    public class PageData<T>
    {
        public List<T> Data { get; set; }
        public int TotalRecord { get; set; }

        public int PageSize { get; set; }
        public int TotalPage { 
            get {
                return TotalRecord / PageSize + (TotalRecord % PageSize == 0 ? 0 : 1);
            } 
        }
    }
}
