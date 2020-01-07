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
    public class userLoginController : ApiController
    {
        [System.Web.Http.HttpPost]
        public int Index(userInfo obj)
        {

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWUserSignUp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = obj.username;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.email_phone;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = obj.password;
                cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = obj.mac_address;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;
        }
    }
}
