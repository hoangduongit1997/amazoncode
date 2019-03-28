using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;
using PagedList;
namespace Amazon.DAL
{
    public class ProductDAL
    {
        ShopDbContext db = null;
        public ProductDAL()
        {
            db = new ShopDbContext();
        }
        public List<Product> GetAll()
        {
            return db.Products.Select(t => t).ToList();
        }
        public List<Product> GetByType(string id)
        {
            return db.Products.Where(t => t.product_type_code == id).ToList();
        }
        public Product ViewDetail(string id)
        {
            var product = db.Products.Find(id);          
            return product;
        }      
        public List<Product> ListRelatedProducts(string productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.product_id != productId && x.product_type_code == product.product_type_code).ToList();
        }

        public bool Insert(Product product)
        {
            bool status;
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                status = true;
            }
            catch(Exception)
            {
                status = false;
            }
            return status;
        }
        public string autoKey()
        {
            //string key = "";
            //List<Product> lst = db.Products.Select(t => t).ToList<Product>();
            //if (db.Products.Count() != 0)
            //{
            //    Product pr = lst[db.Products.Max(t => int.Parse(t.product_id))];
            //    key = (int.Parse(pr.product_id) + 1).ToString();
            //}
            //return key;
            int stt = 0;
            string num = "", key = "";
            List<Product> lst = db.Products.Select(t => t).ToList<Product>();
            if (db.Ref_Product_Types.Count() != 0)
            {
                try
                {
                    Product hv = lst[db.Products.Count() - 1];
                    string[] ma = hv.product_type_code.Trim().Split('D');
                    stt = (int.Parse(ma[1]) + 1);
                    if (stt < 10)
                        num = "00";
                    else
                        num = "0";
                    key = "PROD" + num + stt;
                }
                catch(Exception)
                {
                     key = "PROD000";
                }
            }
            return key;
        }
        public IEnumerable<Product> ListAllPaging(int page, int pageSize)
        {
            return db.Products.OrderByDescending(x => x.product_name).ToPagedList(page, pageSize);
        }

        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.product_id);
                product.product_name = entity.product_name;
                product.product_price = entity.product_price;
                product.product_size = entity.product_size;
                product.product_description = entity.product_description;
                product.product_color = entity.product_color;
                product.product_imge = entity.product_imge;
                product.promotionprice = entity.promotionprice;
                product.createddate = entity.createddate;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Product GetById(string productName)
        {
            return db.Products.SingleOrDefault(x => x.product_name == productName);
        }
        public bool Delete(Product product)
        {
            bool status;
            try
            {
                var type = db.Products.Find(product.product_id);
                db.Products.Remove(type);
                db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public void UpdateImages(string productId, string images)
        {
            var product = db.Products.Find(productId);
            product.more_image = images;
            db.SaveChanges();
        }
        public List<Product> ListNewProduct()
        {
            var lst = db.Products.OrderByDescending(t => t.createddate).Take(5).ToList();
            return lst;
        }
        public List<Product> ListProductOfType(string id)
        {
            var list = db.Products.Where(pr => pr.product_type_code == id).ToList();
            return list;
        }
        public List<Product> TopDealProduct()
        {
            var lst = db.Products.OrderByDescending(t => t.createddate).Take(5).ToList();
            return lst;
        }

    }
}
