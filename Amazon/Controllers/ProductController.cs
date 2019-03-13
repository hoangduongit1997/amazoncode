using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amazon.BUS;

namespace Amazon.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductDetails
        public ActionResult Index(string typeID)
        {
            var listProduct = new ProductBUS().ListProductOfType(typeID);
            ViewBag.ProductType = new ProductTypeBUS().ListAllProductType();
            return View(listProduct);
        }
        public ActionResult Show(string id)
        {
            var product = new ProductBUS().ViewDetail(id);
            ViewBag.RelatedProducts = new ProductBUS().ListRelatedProducts(id);
            ViewBag.ProductType = new ProductTypeBUS().ListAllProductType();
            return View(product);

        }
        public ActionResult Detail(string id)
        {
            var product = new ProductBUS().ViewDetail(id);
            ViewBag.RelatedProducts = new ProductBUS().ListRelatedProducts(id);
            return View(product);
        }
    }
}