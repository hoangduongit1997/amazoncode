using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Amazon.DTO;
using Newtonsoft.Json;
using AmazonWebAPI;
using AmazonWebAPI.Controllers;
using Amazon.Areas.Admin.Models;

namespace Amazon.Areas.Admin.Controllers
{
    public class Ref_Product_TypesController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:62993/api";
        private ProductTypesController ctrl = new ProductTypesController();

        public Ref_Product_TypesController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        //index
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/productTypes/GetAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var product = JsonConvert.DeserializeObject<List<Ref_Product_TypesDTO>>(responseData, settings);
                return View(product);
            }
            return View();
        }
        //get view create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public string autoKey()
        {
            string key = ctrl.autoKey();
            if (key != null)
                return key;
            return "TYPE0001";
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductTypeModel model)
        {
            string key = autoKey();
            try
            {
                if (ModelState.IsValid)
                {
                    var type = new Ref_Product_TypesDTO();
                    if (key != null)
                        type.product_type_code = key;
                    else
                        type.product_type_code = model.product_type_code;
                    type.product_type_description = model.description;
                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "/ProductTypes", type);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        //var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                        var settings = new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            MissingMemberHandling = MissingMemberHandling.Ignore
                        };
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error");
            }
            return View(model);
        }
        //get view edit
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var responseMessage = client.GetAsync(url + "/ProductTypes/ProductTypeID="+id);
            responseMessage.Wait();
            var result = responseMessage.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var type = JsonConvert.DeserializeObject<Ref_Product_TypesDTO>(readTask, settings);
                return View(type);
            }
            return View();
        }
        //update value
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "product_type_code,product_type_description")] Ref_Product_TypesDTO ref_Product_Types)
        {
            if (ModelState.IsValid)
            {
                var response = await client.PutAsJsonAsync("api/ProductTypes/ProductTypeID="+ref_Product_Types.product_type_code, ref_Product_Types);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error");
                }
                return RedirectToAction("Index");
            }
            return View(ref_Product_Types);
        }
        //delete
        public ActionResult Delete(string id)
        {
            var responseMessage = client.GetAsync(url + "/ProductTypes/ProductTypeID=" + id);
            responseMessage.Wait();
            var result = responseMessage.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var type = JsonConvert.DeserializeObject<Ref_Product_TypesDTO>(readTask, settings);
                return View(type);
            }
            return View();
        }
        //confirm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var responseMessage = client.GetAsync(url + "/ProductTypes/ProductTypeID=" + id);
            responseMessage.Wait();
            var result = responseMessage.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var type = JsonConvert.DeserializeObject<Ref_Product_TypesDTO>(readTask, settings);
                ctrl.DeleteProductType(type);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

            //    protected override void Dispose(bool disposing)
            //    {
            //        if (disposing)
            //        {
            //            db.Dispose();
            //        }
            //        base.Dispose(disposing);
            //    }
        }
}
