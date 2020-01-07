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
    public class getUsernameController : ApiController
    {
        [System.Web.Http.HttpPost]
        public string Index(userInfo obj)
        {
            String username = "";
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWGetUserName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = obj.mac_address;
                username=cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception e)
            {
                return "";
            }
            return username;
        }
    
    }
}
