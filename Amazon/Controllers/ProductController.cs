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
using AmazonWebAPI.Controllers;

namespace Amazon.Controllers
{
    public class ProductController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:62993/api/product";


        public ProductController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        ProductTypesController ctrl = new ProductTypesController();
        //public async Task<ActionResult> Index()
        //{
        //HttpResponseMessage responseMessage = await client.GetAsync(url + "/GetAll");
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
        //    var settings = new JsonSerializerSettings
        //    {
        //        NullValueHandling = NullValueHandling.Ignore,
        //        MissingMemberHandling = MissingMemberHandling.Ignore
        //    };
        //    var product = JsonConvert.DeserializeObject<List<ProductDTO>>(responseData, settings);

        //    // return View(product);
        //    //var lst = new ProductBUS().ListNewProduct();
        //    ViewBag.NewProduct = product;
        //    //var topdeal = new ProductBUS().TopDealProduct();
        //    ViewBag.TopDeal = product;
        //        //ViewBag.SessionUser = Session["Customer"];
        //        return View(product);
        //    }
        //    return View();
        //}
        //[Route("typeID={typeid?}")]
        public async Task<ActionResult> Index(string typeid)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/ProductType="+typeid);
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
                ViewBag.ProductType = ctrl.Get();
                ViewBag.NewProduct = product;
                //var topdeal = new ProductBUS().TopDealProduct();
                ViewBag.TopDeal = product;
                //ViewBag.SessionUser = Session["Customer"];
                return View(product);
            }
            return View();
        }
        [Route("{name?}p{id?}")]
        //[Route("{productId}/{productTitle}")]
        public async Task<ActionResult> Show(string id, string name)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/ProductID="+ id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var product = JsonConvert.DeserializeObject<ProductDTO>(responseData, settings);
                //name = product.product_name;
                return View(product);
            }
            return View("Error");
        }
        //        public ActionResult Detail(string id)
        //        {
        //            var product = new ProductBUS().ViewDetail(id);
        //            ViewBag.RelatedProducts = new ProductBUS().ListRelatedProducts(id);
        //            return View(product);
        //        }
    }
}