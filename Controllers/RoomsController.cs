using RoomsMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoomsMgmtSystem.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        // GET: Rooms
        string myConnectionString = "server=localhost;uid=root;" + "database=DB_ROOM_MGMT_SYSTEM; SslMode = none";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerList()
        { 
            List<RegistrationDetails> lstCust = new List<RegistrationDetails>();
            lstCust = GetCustomerDetail();
            return View(lstCust); 
        }


        public List<RegistrationDetails> GetCustomerDetail()
        {
            List<RegistrationDetails> lstRD = new List<RegistrationDetails>();
            DataSet ds = new DataSet("Detail");
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString))
            {
                MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter("select * from tbl_Customer_DET o WHERE o.Roles='Tanants'", conn);
                da.Fill(ds);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    RegistrationDetails RD = new RegistrationDetails();
                    RD.ID = dr["ID"].ToString();
                    RD.Name = dr["Name"].ToString();
                    RD.FirstName = dr["FirstName"].ToString();
                    RD.LastName = dr["LastName"].ToString();
                    RD.City = dr["City"].ToString();
                    RD.Address = dr["Address"].ToString();
                    RD.Email = dr["Email"].ToString();
                    RD.Phone = dr["Phone"].ToString();
                    RD.Roles = dr["Roles"].ToString();
                    lstRD.Add(RD);
                }
            }
            return lstRD;
        }

        public ActionResult RoomsDetails()
        {
            //List<RegistrationDetails> lstCust = new List<RegistrationDetails>();
            //lstCust = GetCustomerDetail();
            //return View(lstCust);
            return View();
        }
    }
}