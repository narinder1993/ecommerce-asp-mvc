using LovelyWannabuy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LovelyWannabuy.Controllers
{
    public class cartQuantityController : ApiController
    {
        [HttpPost]
        public int Index(cart obj)
        {
            int qty;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWcartQty";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = obj.mac;
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = obj.productId;
                qty=  Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();
                return qty;
                
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
