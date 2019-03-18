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

namespace Amazon.Areas.Admin.Controllers
{
    public class Ref_Product_TypesController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:62993/api";


        public Ref_Product_TypesController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Ref_Product_TypesDTO model)
        {
            if (ModelState.IsValid)
            {
                var type = new Ref_Product_TypesDTO();
                type.product_type_code = model.product_type_code;
                type.product_type_description = model.product_type_description;
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
            return View(model);
        }
        //[HttpGet]
        //public ActionResult Edit(string id)
        //{
        //    Ref_Product_TypesDTO type = null;

        //    var responseTask = client.GetAsync("/ProductTypes/ProductTypeID=" + id.ToString());
        //    responseTask.Wait();

        //    var result = responseTask.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<Ref_Product_TypesDTO>();
        //        readTask.Wait();

        //        type = readTask.Result;
        //    }

        //    return View(type);
        //}
        /*edit*/
        //[HttpGet]
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    Ref_Product_TypesDTO ref_Product_Types = db.Ref_Product_Types.Find(id);
        //    if (ref_Product_Types == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ref_Product_Types);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Edit(Ref_Product_TypesDTO type)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/ProductTypes", type);
        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            var responseData = responseMessage.Content.ReadAsStringAsync().Result;
        //            var settings = new JsonSerializerSettings
        //            {
        //                NullValueHandling = NullValueHandling.Ignore,
        //                MissingMemberHandling = MissingMemberHandling.Ignore
        //            };
        //            var product = JsonConvert.DeserializeObject<Ref_Product_TypesDTO>(responseData, settings);
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(type);
        //}
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "product_type_code,product_type_description")] Ref_Product_Types ref_Product_Types)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(ref_Product_Types).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(ref_Product_Types);
        //    }

        //    // GET: Admin/Ref_Product_Types/Delete/5
        //    public ActionResult Delete(string id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Ref_Product_Types ref_Product_Types = db.Ref_Product_Types.Find(id);
        //        if (ref_Product_Types == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(ref_Product_Types);
        //    }

        //    // POST: Admin/Ref_Product_Types/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(string id)
        //    {
        //        Ref_Product_Types ref_Product_Types = db.Ref_Product_Types.Find(id);
        //        db.Ref_Product_Types.Remove(ref_Product_Types);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

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
