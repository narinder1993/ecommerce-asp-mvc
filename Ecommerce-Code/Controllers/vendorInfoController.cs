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
    public class vendorInfoController : ApiController
    {
         
        [System.Web.Http.HttpPost]

        public vendor Index(vendor obj)
        {
            vendor res=new vendor ();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "pSMWFetchVendor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.email;
                cmd.Parameters.Add("@password", SqlDbType.Int).Value = obj.password;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    res.name=dr["name"].ToString();
                    res.address=dr["address"].ToString();
                    res.city=dr["city"].ToString();
                    res.state=dr["state"].ToString();
                    res.contact=dr["contact"].ToString();
                    res.pincode=dr["pincode"].ToString();
                    
                }

                con.Close();
            }
            catch (Exception e)
            {
                res.name="Error";
            }
            
            return res;
        }
    
    }
}
