using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_two.helpers
{
    public class QueryObject
    {
        public string? Symbol { get; set;} = null;

        public string? CompanyName { get; set;} = null;

        public string? SortBy { get; set;} = null;


        public bool isDescending { get; set; } = false;
    }
}