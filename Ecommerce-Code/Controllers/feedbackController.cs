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
    public class feedbackController : ApiController
    {
        public void Index(feedback a)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWFeedback";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = a.name;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = a.email;
                cmd.Parameters.Add("@comment", SqlDbType.VarChar).Value = a.comment;
                
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
