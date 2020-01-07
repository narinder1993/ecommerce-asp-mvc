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
    public class productDescriptionController : ApiController
    {
        public List<product> prod=new List<product>();
        [System.Web.Http.HttpPost]
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
                cmd.CommandText = "pSMWGetProductDescription";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = obj.id;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if ((dr["Path"].ToString()).Equals("") == false)
                    {
                        prod.Add(new product() { id = (dr["Id"].ToString()), path = dr["Path"].ToString(), name = (dr["Name"].ToString()), price = (dr["SalePrice"].ToString()), billName = (dr["ProductBillName"].ToString()), MRP = (dr["MRP"].ToString()), discount=(dr["Discount"].ToString()), inStock=(dr["stock"].ToString())});
                    }
                    else
                    {
                        prod.Add(new product() { id = (dr["Id"].ToString()), path = "/Images/products/noimage.jpg", name = (dr["Name"].ToString()), price = (dr["SalePrice"].ToString()), billName = (dr["ProductBillName"].ToString()), MRP = (dr["MRP"].ToString()), discount = (dr["Discount"].ToString()), inStock = (dr["stock"].ToString()) });
                    }

                }

                con.Close();
            }
            catch (Exception e)
            {
                prod.Add(new product() { id = "-1", path = "Error :" + e.Message.ToString() });
            }
            return prod;
        }
    }
    }

