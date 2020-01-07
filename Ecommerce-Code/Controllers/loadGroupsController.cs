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
    public class loadGroupsController : ApiController
    {
        public List<groupInfo> images = new List<groupInfo>();
        [System.Web.Http.HttpPut]

        public List<groupInfo> Index(product a)
        {

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWGetGroupInfo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@text", SqlDbType.NVarChar).Value = a.name.ToString();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if ((dr["ImagePath"].ToString()).Equals("") == false)
                    {
                        images.Add(new groupInfo() { id = (dr["Id"].ToString()), ImagePath = dr["ImagePath"].ToString(), name = (dr["Name"].ToString()) });
                    }
                    else
                    {
                        images.Add(new groupInfo() { id = (dr["Id"].ToString()), ImagePath = "/Images/products/noimage.jpg", name = (dr["Name"].ToString()) });
                    }

                }

                con.Close();
            }
            catch (Exception e)
            {
                images[0].name = "error";
                return images;
            }
            return images;
        }
    
    }
}
