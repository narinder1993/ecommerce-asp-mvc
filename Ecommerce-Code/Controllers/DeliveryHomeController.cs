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
    public class DeliveryHomeController : ApiController
    {
        [HttpPost]
        public void Index(HomeDel a)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWDeliveryHome";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = a.username;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = a.email;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = a.address;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = a.city;
                cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = a.state;
                cmd.Parameters.Add("@pincode", SqlDbType.VarChar).Value = a.pincode;
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = a.mobile;
                cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = a.mac;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
