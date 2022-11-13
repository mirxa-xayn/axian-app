using System;
using System.Collections.Generic;
using System.Text;

namespace Axian.Models.Generic
{
    public class ReturnModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object data { get; set; }
    }
}
