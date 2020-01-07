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
    public class top_sellingController : ApiController
    {
        public List<product> images = new List<product>();
        [System.Web.Http.HttpPut]

        public List<product> Index(product obj)
        {

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWGetTopSelling";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@count", SqlDbType.Int).Value = obj.count;
                cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = obj.pageSize;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if ((dr["Path"].ToString()).Equals("") == false)
                    {
                        images.Add(new product() { id = (dr["Id"].ToString()), path = dr["Path"].ToString(), name = (dr["Name"].ToString()), price = (dr["SalePrice"].ToString()), MRP = dr["MRP"].ToString() });
                    }
                    else
                    {
                        images.Add(new product() { id = (dr["Id"].ToString()), path = "/Images/products/noimage.jpg", name = (dr["Name"].ToString()), price = (dr["SalePrice"].ToString()), MRP = dr["MRP"].ToString() });
                    }
                }

                con.Close();
            }
            catch (Exception e)
            {
                images.Add(new product() { id = "-1", path = "Error :" + e.Message.ToString() });
            }
            return images;
        }
    }
}
