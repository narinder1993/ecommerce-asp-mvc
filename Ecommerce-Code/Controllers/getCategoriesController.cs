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
    public class getCategoriesController : ApiController
    {
        public List<product> images = new List<product>();
        [System.Web.Http.HttpGet]
        public List<product> Index()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "getCategories";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {                    
                        images.Add(new product {name=dr["name"].ToString(), id=dr["id"].ToString()});
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
