using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Amazon.Models;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using Amazon.DTO;
namespace Amazon.Controllers
{
    public class ProductController : Controller
    {
        HttpClient client;  
        string url = "http://localhost:62993/api/product";
        public ProductController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
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
                return View(product);
            }
    return View();
}
        //        public async Task<ActionResult> Index(string typeID)
        //        {

        //            HttpResponseMessage responseMessage = await client.GetAsync(url+ "/Category="+typeID);
        //            if (responseMessage.IsSuccessStatusCode)
        //            {
        //                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
        //                var settings = new JsonSerializerSettings
        //                {
        //                    NullValueHandling = NullValueHandling.Ignore,
        //                    MissingMemberHandling = MissingMemberHandling.Ignore
        //                };
        //                var product = JsonConvert.DeserializeObject<List<Product>>(responseData, settings);
        //                ViewBag.ProductType = new ProductTypeBUS().ListAllProductType();
        //                return View(product);
        //            }
        //            return View("Error");
        //        }
        //        // GET: ProductDetails
        //        //public ActionResult Index(string typeID)
        //        //{
        //        //    var listProduct = new ProductBUS().ListProductOfType(typeID);
        //        //    ViewBag.ProductType = new ProductTypeBUS().ListAllProductType();
        //        //    return View(listProduct);
        //        //}
        public async Task<ActionResult> Show(string id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/ProductID="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var product = JsonConvert.DeserializeObject<ProductDTO>(responseData, settings);
                return View(product);
            }
            return View("Error");
        }
      
    }
}