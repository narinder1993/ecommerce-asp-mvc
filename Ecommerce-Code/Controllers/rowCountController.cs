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
    public class rowCountController : ApiController
    {
        [HttpPut]
        public int Index(search obj)
        {
            int n;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "GetRowCount";
                cmd.CommandType = CommandType.StoredProcedure;
                string s=obj.txtSearch.ToString();
                cmd.Parameters.Add("@txtSearch", SqlDbType.VarChar).Value =s ;
                n = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception e)
            {
                return 0;
            }
            return n;
        }
    }
}
