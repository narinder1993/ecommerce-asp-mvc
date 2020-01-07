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
    public class fetchOrdersController : ApiController
    {
        public List<orders> order = new List<orders>();
        [System.Web.Http.HttpPut]

        public List<orders> Index(userInfo obj)
        {

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWFetchOrders";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value =obj.username;
                cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = obj.mac_address;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    order.Add(new orders() { address = (dr["address"].ToString()), orderNo = (dr["orderNo"].ToString()), product = dr["Name"].ToString(), quantity = (dr["productQty"].ToString()), deliveryDate = (dr["deliveryDate"].ToString()), status = dr["status"].ToString(), deliveryType = dr["deliveryType"].ToString(), amount = dr["Due"].ToString(), orderDate = dr["orderDate"].ToString() });
                }

                con.Close();
            }
            catch (Exception e)
            {
                order.Add(new orders() { orderNo = "-1", product = "Error :" + e.Message.ToString() });
            }

            return order;
        }
    }
}
