using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LovelyWannabuy.Models
{
    public class search
    {
        public int count { get; set; }
        public string txtSearch { get; set; }
        public string category { get; set; }
        public int pageSize { get; set; }
    }
}