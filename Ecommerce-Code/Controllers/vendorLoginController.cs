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
    public class vendorLoginController : ApiController
    {
        [System.Web.Http.HttpPost]
        public int Index(vendor obj)
        {
            int flag = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWVendorSignIn";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = obj.password;
                flag =Convert.ToInt16( cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception e)
            {
                return 0;
            }
            return flag;
        }

    }
}
