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
    public class vendorRegController : ApiController
    {
        public void Index(vendor a)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWVendorReg";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = a.name;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = a.email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = a.password;
                cmd.Parameters.Add("@contact", SqlDbType.VarChar).Value = a.contact;
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = a.address;
                cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = a.state;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = a.city;
                cmd.Parameters.Add("@pincode", SqlDbType.VarChar).Value = a.pincode;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
