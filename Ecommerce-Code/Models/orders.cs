using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LovelyWannabuy.Models
{
    public class orders
    {
        public string orderNo { get; set; }
        public string product { get; set; }
        public string quantity { get; set; }
        public string deliveryDate { get; set; }
        public string orderDate { get; set; }
        public string status { get; set; }
        public string totalQty { get; set; }
        public string amount { get; set; }
        public string address { get; set; }
        public string deliveryType { get; set; }
    }
}