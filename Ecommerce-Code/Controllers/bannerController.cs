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
    public class bannerController : ApiController
    {
        public List<banner> images = new List<banner>();
        [System.Web.Http.HttpPost]

        public List<banner> Index()
        {

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWgetBanner";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    images.Add(new banner() { header1 = (dr["Header1"].ToString()), header2 = dr["Header2"].ToString(), header3 = (dr["Header3"].ToString()), description = (dr["description"].ToString()), type = dr["type"].ToString(), imagePath=dr["path"].ToString(), typeId=dr["typeId"].ToString() });
                    

                }

                con.Close();
            }
            catch (Exception e)
            {
                images.Add(new banner() { typeId = "-1", imagePath = "Error :" + e.Message.ToString() });
            }
            return images;
        }
    }
}
