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
    public class editProfileController : ApiController
    {
        [System.Web.Http.HttpPost]
        public int Index(userInfo obj)
        {
            userInfo user = new userInfo();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWEditProfile";
                cmd.CommandType = CommandType.StoredProcedure;
                if (obj.mobile == null)
                {
                    obj.mobile = "";
                }
                if (obj.pincode == null)
                {
                    obj.pincode = "";
                }
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = obj.username.ToString();
                cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = obj.mac_address.ToString();
                cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = obj.mobile.ToString();
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.email_phone.ToString();
                cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = obj.address.ToString();
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = obj.city.ToString();
                cmd.Parameters.Add("@state", SqlDbType.VarChar).Value = obj.state.ToString();
                cmd.Parameters.Add("@pin", SqlDbType.VarChar).Value = obj.pincode.ToString();
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
