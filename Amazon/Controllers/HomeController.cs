using Amazon.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace Amazon.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;      
        string url = "http://localhost:62993/api";
        // GET: Home
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/product/GetAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var product = JsonConvert.DeserializeObject<List<ProductDTO>>(responseData, settings);             
                ViewBag.NewProduct = product;            
                ViewBag.TopDeal = product;
                //ViewBag.SessionUser = Session["Customer"];
            }
            return View();
        }        
        [ChildActionOnly]
        public async Task<PartialViewResult> MainMenu()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/Home/Menu");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var list_menu = JsonConvert.DeserializeObject<List<MenuDTO>>(responseData, settings);
                return PartialView(list_menu);
            }
           
            return PartialView();
        }
        [ChildActionOnly]
        public async  Task<PartialViewResult> Slider()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/Home/Slide");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var list_slide =JsonConvert.DeserializeObject<List<SlideDTO>>(responseData, settings);
                return PartialView(list_slide);
            }
            return PartialView();
        }
        //public PartialViewResult Footer()
        //{
        //    var footer = new FooterBUS().ListFooterBUS().ToList();
        //    return PartialView(footer);

        //}
    }
}