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

namespace Amazon.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        //
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:62993/api/product";


        public ProductsController()
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

                // return View(product);
                //var lst = new ProductBUS().ListNewProduct();
                //ViewBag.NewProduct = product;
                //var topdeal = new ProductBUS().TopDealProduct();
                //ViewBag.TopDeal = product;
                //ViewBag.SessionUser = Session["Customer"];
                return View(product);
            }
            return View();
        }
        //public async Task<ActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
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
        //        if (searchString != null)
        //        {
        //            page = 1;
        //        }
        //        else
        //        {
        //            searchString = currentFilter;
        //        }
        //        ViewBag.currentFilter = searchString;
        //        ///var product = from pr in db.Products select pr;
        //        if (!String.IsNullOrEmpty(searchString))
        //        {
        //            product = product.Where(t => t.product_name.Contains(searchString));
        //        }
        //        product = product.OrderBy(s => s.product_id);
        //        int pageSize = 5;
        //        int pageNum = (page ?? 1);
        //        return View(product);
        //    }
        //    return View();
        //}
        //
        //private ShopDbContext db = new ShopDbContext();


        //public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        //{

        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }
        //    ViewBag.currentFilter = searchString;
        //    var product = from pr in db.Products select pr;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        product = product.Where(t => t.product_name.Contains(searchString));
        //    }
        //    product = product.OrderBy(s => s.product_id);
        //    int pageSize = 5;
        //    int pageNum = (page ?? 1);
        //    return View(product.ToPagedList(pageNum, pageSize));
        //}
        ////CREATE
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    ViewBag.product_type_code = new SelectList(db.Ref_Product_Types, "product_type_code", "product_type_description");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult Create(Product product, HttpPostedFileBase file)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string path = Path.Combine(Server.MapPath("~/Upload/image/product/images"), Path.GetFileName(file.FileName));
        //        if (System.IO.File.Exists(path))
        //        {
        //            ViewBag.ThongBao = "This picture existed";
        //        }
        //        else
        //        {
        //            file.SaveAs(path);
        //        }
        //        db.Products.Add(new Product
        //        {
        //            product_id = product.product_id,
        //            product_type_code = product.product_type_code,
        //            product_name = product.product_name,
        //            product_price = product.product_price,
        //            product_description = product.product_description,
        //            product_size = product.product_size,
        //            product_color = product.product_color,
        //            product_imge = "/Upload/image/product/images/" + file.FileName,

        //            createddate = product.createddate = DateTime.Now,
        //            promotionprice = product.promotionprice
        //        });
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.product_type_code = new SelectList(db.Ref_Product_Types, "product_type_code", "product_type_description", product.product_type_code);
        //    return View(product);
        //}

        ////EDIT

        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.product_type_code = new SelectList(db.Ref_Product_Types, "product_type_code", "product_type_description", product.product_type_code);
        //    return View(product);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "product_id,product_type_code,product_name,product_price,product_description,product_size,product_color,product_imge,more_image,createddate,promotionprice")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var pd = new ProductBUS();
        //        var result = pd.Update(product);
        //        if (result)
        //        {
        //            return RedirectToAction("Index", "Products");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Cập nhật sản phẩm thất bại");
        //        }
        //    }
        //    ViewBag.product_type_code = new SelectList(db.Ref_Product_Types, "product_type_code", "product_type_description", product.product_type_code);
        //    return View(product);
        //}


        //// DELETE
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(product);
        //}
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Product product = db.Products.Find(id);
        //    db.Products.Remove(product);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
