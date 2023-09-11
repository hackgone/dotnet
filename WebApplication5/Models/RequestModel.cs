using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class RequestModel
    {
        public int[] employee_id { get; set; }
        public string[] columns { get; set; }
        public string depart_name { get; set; }
    }
}
