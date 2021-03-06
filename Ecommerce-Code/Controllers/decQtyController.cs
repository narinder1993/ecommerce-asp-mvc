﻿using LovelyWannabuy.Models;
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
    public class decQtyController : ApiController
    {
        [HttpPost]
        public void index(cart obj)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWcartQtyDecrease";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = obj.mac;
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = obj.productId;
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = obj.username;
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception e)
            {
                
            }
        }
    }
}
