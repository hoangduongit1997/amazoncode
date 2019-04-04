using Amazon.DTO;
using AmazonWebAPI.Controllers;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Areas.Admin.Controllers
{
    public class SlidesController : Controller
    {
        HttpClient client;
        string url = "http://localhost:62993/api";
        private SlideController ctrl = new SlideController();

        public SlidesController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<ActionResult> Index(string searchString, string currentFilter, int? page)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/slides/GetAll");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var slide = JsonConvert.DeserializeObject<List<SlideDTO>>(responseData, settings);
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
                return View(slide.ToPagedList(pageNum, pageSize));
            }
            return View();
        }
        //
        public string ChuanHoa(string s)
        {
            s = s.Trim();// xóa khoảng trắng đầu và cuối
            while (s.Contains("  ")) //2 khoảng trắng
            {
                s = s.Replace("  ", " "); //Replace 2 khoảng trắng thành 1 khoảng trắng
            }
            return s;
        }
        //
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SlideDTO slide, HttpPostedFileBase file)
        {
            //int key = ctrl.autoKey();
            try
            {
                if (ModelState.IsValid)
                {
                    //Null value
                    string path = Path.Combine(Server.MapPath("~/Upload/image/logo"), Path.GetFileName(file.FileName));
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "This picture existed";
                    }
                    else
                    {
                        file.SaveAs(path);
                    }
                    var sld = new SlideDTO();
                    sld.ID = ctrl.autoKey();
                    //sld.Image = slide.Image;
                    sld.Image = "/Upload/image/logo/" + file.FileName;//file
                    sld.DisplayOrder = slide.DisplayOrder;
                    sld.Link = slide.Link;
                    sld.Description = ChuanHoa(slide.Description);
                    sld.CreatedDate = DateTime.Now;
                    sld.CreatedBy = slide.CreatedBy;
                    sld.ModifiedDate = DateTime.Now;
                    sld.ModifiedBy = slide.ModifiedBy;
                    sld.Status = slide.Status;
                    sld.Priority = null;

                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "/slides", sld);
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
            return View(slide);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var responseMessage = client.GetAsync(url + "/slides/slideID=" + id);
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
                var type = JsonConvert.DeserializeObject<SlideDTO>(readTask, settings);
                type.ModifiedDate = DateTime.Now;
                return View(type);
            }
            return View();
        }
        /*edit*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Image,DisplayOrder,Link,Description,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,Status,Priority")] SlideDTO slide)
        {
            if (ModelState.IsValid)
            {
                var response = await client.PutAsJsonAsync("api/slides/slideID=" + slide.ID, slide);
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
            return View(slide);
        }
        //
        public ActionResult Delete(int id)
        {
            var responseMessage = client.GetAsync(url + "/slides/slideID=" + id);
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
                var foot = JsonConvert.DeserializeObject<SlideDTO>(readTask, settings);
                return View(foot);
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var responseMessage = client.GetAsync(url + "/slides/slideID=" + id);
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
                var foot = JsonConvert.DeserializeObject<SlideDTO>(readTask, settings);
                ctrl.DeleteProductType(foot);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}