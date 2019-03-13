using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amazon.BUS;
using Amazon.EntityFramework;

namespace Amazon.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var lst = new ProductBUS().ListNewProduct();
            ViewBag.NewProduct = lst;
            var topdeal = new ProductBUS().TopDealProduct();
            ViewBag.TopDeal = topdeal;
            ViewBag.SessionUser = Session["Customer"];
            return View();
        }
       
       [ChildActionOnly]
        public PartialViewResult MainMenu()
        {
            var menu = new MenuBUS().ListMenu().ToList();
            return PartialView(menu);
        }
        public ActionResult Slider()
        {
            var slider = new SlideBUS().Sliders().ToList();
            return PartialView(slider);
        }
        public PartialViewResult Footer()
        {
            var footer = new FooterBUS().ListFooterBUS().ToList();
            return PartialView(footer);

        }
    }
}