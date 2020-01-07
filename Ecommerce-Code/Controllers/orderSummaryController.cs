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
   public class orderSummaryController : ApiController
    {
        public List<product> prod = new List<product>();
        [System.Web.Http.HttpPost]
        public List<product> Index(cart obj)
        {

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWOrderSummary";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = obj.mac;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = obj.username;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    prod.Add(new product() { quantity=dr["totalProducts"].ToString(), price=dr["totalDue"].ToString()});
                }

                con.Close();
            }
            catch (Exception e)
            {
                prod.Add(new product() { id = "-1", path = "Error :" + e.Message.ToString() });
            }
            return prod;
        }
    
    }
}
