using LovelyWannabuy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;

namespace LovelyWannabuy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult featuredProducts()
        {
            return View();
        }
        public ActionResult pickUp()
        {
            return View();
        }
        public ActionResult aboutUs()
        {
            return View();
        }
        public ActionResult contactUs()
        { 
        return View();
        }
        public ActionResult editProfile()
        {
            return View();
        }
        public ActionResult Index()
        {
              
                ViewData["cartProds"] = TempData["cartProds"];
                ViewData["amtDue"] = TempData["amtDue"];
                TempData.Keep();            
                return View();
        }

        public ActionResult signin()
        {
            return View();
        }
        public ActionResult signup()
        {
            return View();
        }
        public ActionResult products()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData.Keep();
            return View();
        }

        public ActionResult latestProducts()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData.Keep();
            return View();
        }

        public ActionResult Groups()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData.Keep();
            return View();
        }

        public ActionResult topSelling()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData.Keep();
            return View();
        }

        public ActionResult productDescription()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            string text = TempData["text"].ToString();
            ViewData["prodText"] = text.ToString();
            TempData.Keep();
            return View();
        }

        [HttpPost]
        public ActionResult userGroupClick1(product a)
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData["text"] = a.id.ToString();
            TempData.Keep();
            return View("groupClick");
        }

        public ActionResult groupClick()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            string text = TempData["text"].ToString();
            ViewData["groupText"] = text.ToString();
            TempData.Keep();
            return View();
        }

        public ActionResult deptClick1(product a)
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData["text"] = a.id.ToString();
            TempData.Keep();
            return View("deptClick");
        }

        public ActionResult deptClick()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            string text = TempData["text"].ToString();
            ViewData["deptText"] = text.ToString();
            TempData.Keep();
            return View();
        }
        
        public ActionResult prodClick(product a)
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData["text"] = a.id.ToString();
            TempData.Keep();
            return View("productDescription");
        }

        [HttpPost]
        public ActionResult search1(search obj)
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData["text"] = obj.txtSearch;
            TempData.Keep();
            return View("searchPage");
        }

        public ActionResult searchPage()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            string text = TempData["text"].ToString();
            ViewData["searchText"] = text.ToString();
            TempData.Keep();
            return View();
        }
        public ActionResult orders()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData.Keep();
            return View();
        }
        public ActionResult profile()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData.Keep();
            return View();
        }
        public ActionResult checkout()
        {
            ViewData["cartProds"] = TempData["cartProds"];
            ViewData["amtDue"] = TempData["amtDue"];
            TempData.Keep();            
                
            return View();
        }
        public void cartMaintain(cart a)
        {

            TempData["cartProds"] = a.cartProds;
            TempData["amtDue"] = a.amtDue;
            TempData.Keep();
        }

        public void macCart(cart obj)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["EcommerceCon"].ConnectionString;
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "macClientInfo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mac", SqlDbType.VarChar).Value = obj.mac;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                    TempData["cartProds"] = dr["cartProds"].ToString();
                    TempData["amtDue"] = dr["amtDue"].ToString();
            }
            con.Close();
        }
        public ActionResult delivery()
        {
            return View();
        }
        public ActionResult homedel()
        {
            return View();
        }
        public ActionResult payment()
        {
            ViewData["username"] = TempData["username"].ToString();
            ViewData["email"] = TempData["email"].ToString();
            ViewData["pincode"] = TempData["pincode"].ToString();
            ViewData["address"] = TempData["address"].ToString();
            ViewData["state"] = TempData["state"].ToString();
            ViewData["city"] = TempData["city"].ToString();
            ViewData["mobile"] = TempData["mobile"].ToString();
            return View();
        }
        public ActionResult paymentPickUp()
        {
            ViewData["username"] = TempData["username"].ToString();
            ViewData["email"] = TempData["email"].ToString();
            ViewData["pincode"] = TempData["pincode"].ToString();
            ViewData["time"] = TempData["time"].ToString();
            ViewData["date"] = TempData["date"].ToString();
            ViewData["mac"] = TempData["mac"].ToString();
            ViewData["mobile"] = TempData["mobile"].ToString();
            return View();
        }
        public ActionResult vendor()
        {
            return View();
        }
        public ActionResult vendorRegisteration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HomeDelivery(HomeDel a)
        {
            TempData["username"] = a.username.ToString();
            TempData["email"] = a.email.ToString();
            TempData["pincode"] = a.pincode.ToString();
            TempData["address"] = a.address.ToString();
            TempData["state"] = a.state.ToString();
            TempData["city"] = a.city.ToString();
            TempData["mobile"] = a.mobile.ToString();
            TempData["mac"] = a.mac.ToString();
            TempData.Keep();
            return View("payment");
        }
        public ActionResult PickDelivery(pickUp a)
        {
            TempData["username"] = a.username.ToString();
            TempData["email"] = a.email.ToString();
            TempData["pincode"] = a.pincode.ToString();
            TempData["date"] = a.date.ToString();
            TempData["time"] = a.time.ToString();
            TempData["mac"] = a.mac.ToString();
            TempData["mobile"] = a.mobile.ToString();
            
            TempData.Keep();
            return View("paymentPickUp");
        }
        public ActionResult vendorPage()
        {
            ViewData["email"] = TempData["email"];
            ViewData["password"] = TempData["password"];
            return View();
        }
        public ActionResult setVendor(vendor a)
        {
            TempData["email"] = a.email;
            TempData["password"] = a.password;
            TempData.Keep();
            return View();
        }
    }
}
