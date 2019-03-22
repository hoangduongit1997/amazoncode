
using Amazon.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Amazon.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Amazon.DTO;

namespace Amazon.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        HttpClient client;
        string url = "http://localhost:62993/api/product";
        public CartController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public ActionResult Index()
        {
            // var User = Session["Customer"];                                  
            var cart = Session[CartSession];
            var list = new List<CartItemModel>();
            if (cart != null)
            {
                list = (List<CartItemModel>)cart;
            }
            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            }
              );
        }
        public JsonResult Delete(string id)
        {
            var SessionCart = (List<CartItemModel>)Session[CartSession];
            SessionCart.RemoveAll(x => x.Product.product_id == id);
            Session[CartSession] = SessionCart;
            return Json(new
            {
                status = true
            }
              );
        }
        public JsonResult Update(string cartModel)
        {
            var JsonCart = new JavaScriptSerializer().Deserialize<List<CartItemModel>>(cartModel);
            var SessionCart = (List<CartItemModel>)Session[CartSession];
            foreach (var item in SessionCart)
            {
                var jsonItem = JsonCart.SingleOrDefault(x => x.Product.product_id == item.Product.product_id);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = SessionCart;
            return Json(new
            {
                status = true
            }
               );
        }
        public async Task<ActionResult> AddItem(string productId, int quantity)
        {
            ProductDTO product = null;
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/ProductID=" + productId);
            if (responseMessage.IsSuccessStatusCode)
            {
               
                 var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                product = JsonConvert.DeserializeObject<ProductDTO>(responseData, settings);
                //return View(product);
            }
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItemModel>)cart;
                if (list.Exists(x => x.Product.product_id == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.product_id == productId)
                            item.Quantity++;
                    }
                }
                else
                {

                    var item = new CartItemModel();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }

            }
            else
            {
                var item = new CartItemModel();            
                item.Quantity = quantity;
                var list = new List<CartItemModel>();
                list.Add(item);
                item.Product = product;
                Session[CartSession] = list;
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            ViewBag.sessionUser = Session["Customer"];
            if (ViewBag.sessionUser != null)
            {
                var cart = Session[CartSession];
                var list = new List<CartItemModel>();
                if (cart != null)
                {
                    list = (List<CartItemModel>)cart;
                }
                return View(list);
            }
            else return RedirectToAction("Login", "User");

        }

        [HttpPost]
        //public ActionResult Payment(string ShipName, string Phone, string Address, string Note)
        //{
        //    var cus_order = (Customer)Session["Customer"];
        //    var order_bus = new OrderBUS();
        //    var order = new Order();
        //    order.date_order = DateTime.Now;
        //    order.order_place = Address;
        //    order.order_note = Note;
        //    order.order_id = "001" + DateTime.Now.Second;
        //    order.customer_id = cus_order.customer_id;
        //    order.order_status_code = 0;
        //    var id = order_bus.Insert(order);
        //    float TotalMoney = 0;
        //    var cart = (List<CartItemModel>)Session[CartSession];
        //    foreach (var item in cart)
        //    {
        //        Random r = new Random();
        //        int or_id = r.Next(10, 99);
        //        var orderitem = new Order_items();
        //        orderitem.order_item_price = item.Product.product_price;
        //        orderitem.order_id = id;
        //        orderitem.product_id = item.Product.product_id;
        //        orderitem.order_item_quantity = item.Quantity;
        //        orderitem.order_item_id = id + DateTime.Now.Second + or_id.ToString();
        //        orderitem.order_item_status_code = 0;
        //        var idd = new OrderItemBUS().Insert(orderitem);
        //        TotalMoney += (float)(item.Product.product_price * item.Quantity);
        //    }
        //    order.total_price = (decimal)TotalMoney;
        //    order_bus.Update(order);



        //    return Redirect("Success");
        //}

        public ActionResult Success()
        {
            return View();
        }
    }
}
