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
    public class MenusController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:62993/api";
        private MenuController ctrl = new MenuController();

        public MenusController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<ActionResult> Index(string searchString, string currentFilter, int? page)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/Menus/GetAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var menu = JsonConvert.DeserializeObject<List<MenuDTO>>(responseData, settings);
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
                return View(menu.ToPagedList(pageNum, pageSize));
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
        public async Task<ActionResult> Create(MenuDTO menu)
        {
            int key = ctrl.autoKey();
            try
            {
                if (ModelState.IsValid)
                {//MenuID, Text, Link DisplayOrder Target Status MenuTypeID MenuParentID Icon Properti 
                    var model = new MenuDTO();
                    model.MenuID = key;
                    model.Text = menu.Text;
                    model.Link = menu.Link;
                    model.DisplayOrder = menu.DisplayOrder;
                    model.Target = "_self";
                    model.Status = menu.Status;
                    model.MenuTypeID = menu.MenuTypeID;
                    model.MenuParentID = menu.MenuParentID;
                    model.Icon = menu.Icon;
                    model.Properti = menu.Properti;
                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "/menus", model);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var settings = new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            MissingMemberHandling = MissingMemberHandling.Ignore
                        };
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error: "+ex.ToString());
            }
            return View(menu);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var responseMessage = client.GetAsync(url + "/Menus/menuID=" + id);
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
                var type = JsonConvert.DeserializeObject<MenuDTO>(readTask, settings);
                return View(type);
            }
            return View();
        }
        /*edit*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MenuID,Text,Link,DisplayOrder,Target,Status,MenuTypeID,MenuParentID,Icon,Properti")] MenuDTO menu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await client.PutAsJsonAsync("api/Menus/menuID=" + menu.MenuID, menu);
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
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error: " + ex.ToString());
            }
            return View(menu);
        }
        //
        public ActionResult Delete(int id)
        {
            var responseMessage = client.GetAsync(url + "/Menus/menuID=" + id);
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
                var menu = JsonConvert.DeserializeObject<MenuDTO>(readTask, settings);
                return View(menu);
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var responseMessage = client.GetAsync(url + "/menus/menuID=" + id);
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
                var menu = JsonConvert.DeserializeObject<MenuDTO>(readTask, settings);
                ctrl.DeleteProductType(menu);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}