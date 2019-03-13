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
        /*
         * This is Khang's comment
         * Khang is here
         */
        public Product ViewDetail(string id)
        {
            return db.Products.Find(id);
        }

        public List<Product> ListRelatedProducts(string productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.product_id != productId && x.product_type_code == product.product_type_code).ToList();
        }

        public string Insert(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product.product_id;
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

        public bool Delete(string id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
