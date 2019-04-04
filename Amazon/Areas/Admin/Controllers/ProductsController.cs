using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using PagedList;
using Amazon.DTO;
using Amazon.Controllers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using AmazonWebAPI.Services;
using AmazonWebAPI.Controllers;

namespace Amazon.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        //
        HttpClient client;
        string url = "http://localhost:62993/api";
        private ProductApiController ctrl = new ProductApiController();

        public ProductsController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public string ChuanHoa(string s)
        {
            s = s.Trim();// xóa khoảng trắng đầu và cuối
            while (s.Contains("  ")) //2 khoảng trắng
            {
                s = s.Replace("  ", " "); //Replace 2 khoảng trắng thành 1 khoảng trắng
            }
            return s;
        }
        ProductTypesController type = new ProductTypesController();
        //public async Task<ActionResult> Index()
        //{
        //    HttpResponseMessage responseMessage = await client.GetAsync(url + "/GetAll");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var responseData = responseMessage.Content.ReadAsStringAsync().Result;
        //        var settings = new JsonSerializerSettings
        //        {
        //            NullValueHandling = NullValueHandling.Ignore,
        //            MissingMemberHandling = MissingMemberHandling.Ignore
        //        };
        //        var product = JsonConvert.DeserializeObject<List<ProductDTO>>(responseData, settings);

        //        return View(product);
        //    }
        //    return View();
        //}
        public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            HttpResponseMessage responseMessage;// = await client.GetAsync(url + "/products/GetAll");
            if (searchString != null)
            {
                page = 1;
                responseMessage = await client.GetAsync(url + "/products/name=" + searchString );
            }
            else
            {
                searchString = currentFilter;
                responseMessage = await client.GetAsync(url + "/products/GetAll");
            }
            ViewBag.currentFilter = searchString;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var product = JsonConvert.DeserializeObject<List<ProductDTO>>(responseData, settings);
                //if (searchString != null)
                //{
                //    page = 1;

                //}
                //else
                //{
                //    searchString = currentFilter;
                //}
                //ViewBag.currentFilter = searchString;
                //var product = from pr in db.Products select pr;
                //if (!String.IsNullOrEmpty(searchString))
                //{
                //    product = product.Contains(searchString);
                //}
                //product = product.OrderBy(s => s.product_id);
                int pageSize = 5;
                int pageNum = (page ?? 1);
                return View(product.ToPagedList(pageNum, pageSize));
                //return View(product);
            }
            return View();
        }
        //
        //private ShopDbContext db = new ShopDbContext();
        //CREATE
        public string autoKey()
        {
            string key = ctrl.autoKey();
            if (key != null)
                return key;
            return "PROD000";
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.product_type_code = new SelectList(type.Get(), "Ref_Product_TypesDTO.product_type_code", "Ref_Product_TypesDTO.product_type_description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(ProductDTO product, HttpPostedFileBase file)
        {
            string key = autoKey();
            try
            {
                if (ModelState.IsValid)
                {
                    string path = Path.Combine(Server.MapPath("~/Upload/image/product/images"), Path.GetFileName(file.FileName));
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "This picture existed";
                    }
                    else
                    {
                        file.SaveAs(path);
                    }
                    var model = new ProductDTO();
                    model.product_id = key;
                    //model.product_type_code = product.product_type_code;
                    model.product_type_code = "1";
                    model.product_name = product.product_name;
                    model.product_price = product.product_price;
                    model.product_description = ChuanHoa(product.product_description);
                    model.product_size = product.product_size;
                    model.product_color = product.product_color;
                    model.product_imge = "/Upload/image/product/images/" + file.FileName;
                    model.createddate = DateTime.Now;
                    model.promotionprice = product.promotionprice;
                    HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url + "/products", model);
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
                ModelState.AddModelError("", "Error: " + ex.ToString());
            }
            return View(product);
        }

        //EDIT
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var responseMessage = client.GetAsync(url + "/products/productID=" + id);
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
                var model = JsonConvert.DeserializeObject<ProductDTO>(readTask, settings);
                ChuanHoa(model.product_description);
                return View(model);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "product_id,product_type_code,product_name,product_price,product_description,product_size,product_color,product_imge,more_image,createddate,promotionprice")] ProductDTO product)
        {
            ChuanHoa(product.product_description);
            if (ModelState.IsValid)
            {
                var response = await client.PutAsJsonAsync("api/products/productID=" + product.product_id, product);
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
            return View(product);
        }


        //// DELETE
        public ActionResult Delete(string id)
        {
            var responseMessage = client.GetAsync(url + "/products/productID=" + id);
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
                var product = JsonConvert.DeserializeObject<ProductDTO>(readTask, settings);
                return View(product);
            }
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var responseMessage = client.GetAsync(url + "/products/productID=" + id);
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
                var product = JsonConvert.DeserializeObject<ProductDTO>(readTask, settings);
                ctrl.DeleteProductType(product);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //public JsonResult LoadImages(string id)
        //{
        //    ProductBUS pd = new ProductBUS();
        //    var product = pd.ViewDetail(id);
        //    var images = product.more_image;
        //    if (images != null)
        //    {
        //        XElement xImages = XElement.Parse(images);
        //        List<string> listImagesReturn = new List<string>();

        //        foreach (XElement element in xImages.Elements())
        //        {
        //            listImagesReturn.Add(element.Value);
        //        }
        //        return Json(new
        //        {
        //            data = listImagesReturn
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}

        //public JsonResult SaveImages(string id, string images)
        //{
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    var listImages = serializer.Deserialize<List<string>>(images);

        //    XElement xElement = new XElement("Images");

        //    foreach (var item in listImages)
        //    {
        //        var subStringItem = item.Substring(22);
        //        xElement.Add(new XElement("Image", subStringItem));
        //    }
        //    ProductBUS pd = new ProductBUS();
        //    try
        //    {
        //        pd.UpdateImages(id, xElement.ToString());
        //        return Json(new
        //        {
        //            status = true
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new
        //        {
        //            status = false
        //        });
        //    }

        //}
    }
}
