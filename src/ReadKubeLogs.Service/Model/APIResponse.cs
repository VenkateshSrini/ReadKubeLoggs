using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadKubeLogs.Service.Model
{
    public class APIResponse<T>
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }

    }
}
