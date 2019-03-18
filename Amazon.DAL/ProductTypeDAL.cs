using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;
using PagedList;

namespace Amazon.DAL
{
    public class ProductTypeDAL
    {
        ShopDbContext db = null;

        public ShopDbContext Db { get => db; set => db = value; }

        public ProductTypeDAL()
        {
            Db = new ShopDbContext();
        }
        public List<Ref_Product_Types> GetAll()
        {
            return db.Ref_Product_Types.Select(t => t).ToList();
        }
        public Ref_Product_Types ViewDetail(string id)
        {
            return Db.Ref_Product_Types.Find(id);
        }

        public bool Insert(Ref_Product_Types productType)
        {
            Db.Ref_Product_Types.Add(productType);
            Db.SaveChanges();
            return true;
        }
        //List<Ref_Product_Types> types = new List<Ref_Product_Types>();
        //public bool Update(Ref_Product_Types productType)
        //{
        //    if (productType == null)
        //    {
        //        throw new ArgumentNullException("item");
        //    }
        //    int index = types.FindIndex(p => p.product_type_code == productType.product_type_code);
        //    if (index == -1)
        //    {
        //        return false;
        //    }
        //    types.RemoveAt(index);
        //    types.Add(productType);
        //    return true;
        //}
        public bool Update(Ref_Product_Types productType)
        {
            try
            {
                var type = Db.Ref_Product_Types.Find(productType.product_type_code);
                type.product_type_code = productType.product_type_code;
                type.product_type_description = productType.product_type_description;
                Db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public bool Delete(string id)
        //{
        //    try
        //    {
        //        var productType = Db.Ref_Product_Types.Find(id);
        //        Db.Ref_Product_Types.Remove(productType);
        //        Db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        //public List<Ref_Product_Types> ListAllProductType()
        //{
        //    return Db.Ref_Product_Types.OrderBy(t => t.product_type_description).ToList();
        //}
        //public IEnumerable<Ref_Product_Types> ListAllPaging(int page, int pageSize)
        //{
        //    return Db.Ref_Product_Types.OrderByDescending(x => x.product_type_description).ToPagedList(page, pageSize);
        //}
    }
}
