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
    public class signOutController : ApiController
    {
        [System.Web.Http.HttpPost]
        public int Index(userInfo obj)
        {
            Int32 a;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWUserSignOut";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = obj.username;
                cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = obj.mac_address;
                a = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception e)
            {
                return 0;
            }
            return a;
        }
    }
}
