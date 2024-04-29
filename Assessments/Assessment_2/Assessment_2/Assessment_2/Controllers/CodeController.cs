using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment_2.Models;

namespace Assessment_2.Controllers
{
    public class CodeController : Controller
    {
        private NorthwindEntities1 db = new NorthwindEntities1(); 
        public ActionResult CustomersInGermany()
        {
            var customersInGermany = db.Customers.Where(cust => cust.Country == "Germany").ToList();
            return View(customersInGermany);
        }
        public ActionResult CustomerWithOrderId()
        {
            var customerWithOrderId = db.Orders.Where(ord => ord.OrderID == 10248).Select(ord => ord.Customer).FirstOrDefault();
            return View(customerWithOrderId);
        }
    }
}