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
        private readonly ToEntityMapper _mapper = new ToEntityMapper();
        private readonly ToPerfomanceMapper _perfomanceMapper = new ToPerfomanceMapper();
            
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var userModel = Session["usermodel"] as UserViewModel;
            return View(userModel);
        }

        public string GetData()
        {
            var data = _salesRepository.GetSalePerfomances();
            return JsonConvert.SerializeObject(data);
        }

        [HttpPost]
        public void Edit(int? id, DateTime date, string client, string good, string manager, float sum)
        {
            var model = new SalePerfomance(date, client, good, manager, sum, id);
            _mapper.EditEntity(_perfomanceMapper.ConvertPerfomanceToSale(model));    
        }

        [HttpPost]
        public void Create(int? id, DateTime date, string client, string good, string manager, float sum)
        {
            var model = new SalePerfomance(date,client,good,manager,sum,id);
            _mapper.SaveToEntity(_perfomanceMapper.ConvertPerfomanceToSale(model));
        }

        [HttpPost]
        public void Delete(int id)
        {
            _salesRepository.DeleteSale(id);
        }

        public JsonResult GetSales()
        {
            var result = _salesRepository.GetManagerSales();
            return Json(new {Managers = result}, JsonRequestBehavior.AllowGet);
        }
    }
}
