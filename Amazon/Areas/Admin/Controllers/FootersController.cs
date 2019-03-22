using Amazon.DTO;
using AmazonWebAPI.Controllers;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Areas.Admin.Controllers
{
    public class FootersController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:62993/api";
        private FooterController ctrl = new FooterController();

        public FootersController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<ActionResult> Index(string searchString, string currentFilter, int? page)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/Footers/GetAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var footer = JsonConvert.DeserializeObject<List<FooterDTO>>(responseData, settings);
                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }
                ViewBag.currentFilter = searchString;
                int pageSize = 10;
                int pageNum = (page ?? 1);
                //return View(product.ToPagedList(pageNum, pageSize));
                return View(footer.ToPagedList(pageNum, pageSize));
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //public string autoKey()
        //{
        //    string key = ctrl.autoKey();
        //    if (key != null)
        //        return key;
        //    return "TYPE0001";
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FooterDTO footer)
        {
            int key = ctrl.autoKey();
            try
            {
                if (ModelState.IsValid)
                {//FooterID,Contain,Status,FooterIDType,FooterParentID,Link,Target
                    var foot = new FooterDTO();
                    foot.FooterID = key;
                    foot.Contain = footer.Contain;
                    foot.Status = footer.Status;
                    foot.FooterIDType = footer.FooterIDType;
                    foot.FooterParentID = footer.FooterParentID;
                    foot.Link = footer.Link;
                    foot.Target = "_self";
                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "/Footers", foot);
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
            return View(footer);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var responseMessage = client.GetAsync(url + "/Footers/FooterID=" + id);
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
                var type = JsonConvert.DeserializeObject<FooterDTO>(readTask, settings);
                return View(type);
            }
            return View();
        }
        /*edit*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FooterID,Contain,Status,FooterIDType,FooterParentID,Link,Target")] FooterDTO footer)
        {
            if (ModelState.IsValid)
            {
                //client.BaseAddress = new Uri(apiBaseAddress);
                var response = await client.PutAsJsonAsync("api/Footers/FooterID=" + footer.FooterID, footer);
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
            return View(footer);
        }
        //
        // GET: Admin/Ref_Product_Types/Delete/5
        public ActionResult Delete(int id)
        {
            var responseMessage = client.GetAsync(url + "/Footers/FooterID=" + id);
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
                var foot = JsonConvert.DeserializeObject<FooterDTO>(readTask, settings);
                return View(foot);
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var responseMessage = client.GetAsync(url + "/Footers/FooterID=" + id);
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
                var foot = JsonConvert.DeserializeObject<FooterDTO>(readTask, settings);
                ctrl.DeleteProductType(foot);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}