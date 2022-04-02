using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gerencia_Proyectos_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                Session["Mesa"] = Request.QueryString["mesa"];
                int NumMesa = int.Parse(Request.QueryString["mesa"]);
                if (NumMesa > 15)
                {
                    Session["Mesa"] = null;
                }
                else
                {
                    ViewData["n-mesa"] = Session["Mesa"];
                }
            }
            catch
            {

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            Console.WriteLine(email,password);
            return View();
        }
    }
}