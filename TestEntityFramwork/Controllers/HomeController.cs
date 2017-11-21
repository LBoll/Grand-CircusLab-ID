using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using TestEntityFramwork.Models;

namespace TestEntityFramwork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListCustomers()
        {
            //Creating an object for the ORM
            NorthwindEntities ORM = new NorthwindEntities();
            //Load the data from the DBSSet into a data structure
            List<Customer> CustomerList = ORM.Customers.ToList();
            //Filter the data (Optional)
            ViewBag.CustomerList = CustomerList;

            return View("CustomersView");
        }


        public ActionResult ListCustomersByCountry(string Country)
        {
            NorthwindEntities ORM = new NorthwindEntities();

            List<Customer> OutputList = new List<Customer>();

            foreach (Customer CustomerRecord in ORM.Customers.ToList())
            {
                if (CustomerRecord.Country == Country)
                {
                    OutputList.Add(CustomerRecord);
                }
            }

            ViewBag.CustomerList = OutputList;

            return View("CustomersView");

        }

        public ActionResult ListCustomersByID(string customerID)
        {
            NorthwindEntities ORM = new NorthwindEntities();

            List<Customer> OutputList = new List<Customer>();

            foreach (Customer CustomerRecord in ORM.Customers.ToList())
            {
                if (CustomerRecord.CustomerID == customerID)
                {
                    OutputList.Add(CustomerRecord);
                }
            }

            ViewBag.CustomerList = OutputList;

            return View("CustomersView");
        }
    }
}