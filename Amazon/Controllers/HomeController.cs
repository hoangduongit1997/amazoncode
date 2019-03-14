using Amazon.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;      
        string url = "http://localhost:62993/api/product";
        // GET: Home
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/GetAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var product = JsonConvert.DeserializeObject<List<ProductDTO>>(responseData, settings);

               // return View(product);
                //var lst = new ProductBUS().ListNewProduct();
                ViewBag.NewProduct = product;
                //var topdeal = new ProductBUS().TopDealProduct();
                ViewBag.TopDeal = product;
                //ViewBag.SessionUser = Session["Customer"];
            }
            return View();
        }

        //[ChildActionOnly]
        //public PartialViewResult MainMenu()
        //{
        //    var menu = new MenuBUS().ListMenu().ToList();
        //    return PartialView(menu);
        //}
        //public ActionResult Slider()
        //{
        //    var slider = new SlideBUS().Sliders().ToList();
        //    return PartialView(slider);
        //}
        //public PartialViewResult Footer()
        //{
        //    var footer = new FooterBUS().ListFooterBUS().ToList();
        //    return PartialView(footer);

        //}
    }
}