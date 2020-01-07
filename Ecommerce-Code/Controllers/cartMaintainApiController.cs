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

    public class cartMaintainApiController : ApiController
    {
        [HttpPost]
        public void Index( cart a)
        { 
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "cartAdd";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = a.mac;
                cmd.Parameters.Add("@product_id", SqlDbType.VarChar).Value = a.productId;
                cmd.Parameters.Add("@cartProds", SqlDbType.Int).Value = Convert.ToInt32(a.cartProds);
                cmd.Parameters.Add("@amtDue", SqlDbType.Int).Value = Convert.ToInt32(a.amtDue);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = a.username;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
                
            }
        }
    }
}
