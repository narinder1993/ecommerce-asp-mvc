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
    public class profileController : ApiController
    {
        [System.Web.Http.HttpPost]
        public userInfo Index(userInfo obj)
        {
            userInfo user= new userInfo ();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWUserProfileInfo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = obj.username;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                 foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    user.username = dr["username"].ToString();
                    user.email_phone = dr["email_phone"].ToString();
                    user.mobile = dr["mobile"].ToString();
                    user.address = dr["address"].ToString();
                    user.city = dr["city"].ToString();
                    user.state = dr["state"].ToString();
                    user.pincode = dr["pincode"].ToString();
                }
                con.Close();
            }
            catch (Exception e)
            {
                return user;
            }
            return user;
        }
    }
}
