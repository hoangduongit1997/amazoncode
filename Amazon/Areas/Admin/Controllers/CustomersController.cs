using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Amazon.BUS;
using Amazon.EntityFramework;
using System.Net;

namespace Amazon.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Admin/Customers
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var cus = new CustomerBUS();
            var model = cus.ListAll(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var customer = new CustomerBUS().ViewDetail(id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var cus = new CustomerBUS();
                var result = cus.Update(customer);
                if (result)
                {
                    return RedirectToAction("Index", "Customers");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật khách hàng thất bại");
                }
            }
            return View("Index");
        }

        public ActionResult Delete(string id)
        {
            var cus = new CustomerBUS();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = cus.ViewDetail(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var cus = new CustomerBUS();
            cus.Delete(id);
            return RedirectToAction("Index");
        }

    }
}