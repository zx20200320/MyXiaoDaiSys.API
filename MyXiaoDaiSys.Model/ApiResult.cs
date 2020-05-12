using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXiaoDaiSys.Model
{
    public class ApiResult<T>
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public T Result { get; set; }
    }
}
