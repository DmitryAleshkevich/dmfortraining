using System.Web.Mvc;
using SalesMVC.Models;

namespace SalesMVC.Controllers
{
    public class SharedController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Quit()
        {
            Session["usermodel"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userModel = AuthProvider.Authenticate(model.UserName, model.Password);
                if (userModel == null)
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
                else
                {
                    Session["usermodel"] = userModel;
                    return RedirectToAction("Index", "Home");
                }                
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Register(UserViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AuthProvider.CreateNewUser(model.UserName, model.Password, model.UserRole);
            return RedirectToAction("Index", "Home");
        }
        
    }
}