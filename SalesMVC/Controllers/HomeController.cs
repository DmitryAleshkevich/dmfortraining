using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using Newtonsoft.Json;
using SalesMVC.Models;

namespace SalesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly SalesRepository _salesRepository = new SalesRepository();
            
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var userModel = Session["usermodel"] as UserViewModel;
            return View(userModel);
        }

        public string GetData()
        {
            var data = _salesRepository.GetSales();
            return JsonConvert.SerializeObject(data);
        }
    }
}
