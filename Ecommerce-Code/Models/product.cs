using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LovelyWannabuy.Models
{
    public class product
    {
        public string txtSearch { get; set; }
        public string id { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public int count { get; set; }
        public int pageSize { get; set; }
        public string billName { get; set; }
        public string MRP { get; set; }
        public int IsDisplay { get; set; }
        public string quantity { get; set; }
        public string discount { get; set; }
        public string inStock { get; set; }
    }
}