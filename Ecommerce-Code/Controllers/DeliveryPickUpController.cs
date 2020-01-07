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
    public class DeliveryPickUpController : ApiController
    {
        [HttpPost]
        public void Index(pickUp a)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWDeliveryPickUp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = a.username;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = a.email;
                cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = a.date;
                cmd.Parameters.Add("@time", SqlDbType.VarChar).Value = a.time;
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
