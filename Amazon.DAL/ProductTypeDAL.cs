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
        //danh sách loại sản phẩm
        public List<Ref_Product_Types> GetAll()
        {
            return db.Ref_Product_Types.Select(t => t).ToList();
        }
        public Ref_Product_Types ViewDetail(string id)
        {
            return Db.Ref_Product_Types.Find(id);
        }

        //thêm loại sản phẩm
        public bool Insert(Ref_Product_Types productType)
        {
            Db.Ref_Product_Types.Add(productType);
            Db.SaveChanges();
            return true;
        }
        //mã tự động
        public string autoKey()
        {
            int key = 0;
            string num = "";
            List<Ref_Product_Types> lst = Db.Ref_Product_Types.Select(t => t).ToList<Ref_Product_Types>();
            if (Db.Ref_Product_Types.Count() != 0)
            {
                Ref_Product_Types hv = lst[Db.Ref_Product_Types.Count() - 1];
                string[] ma = hv.product_type_code.Trim().Split('E');
                key = (int.Parse(ma[1]) + 1);

            }
            if (key < 10)
                num = "00";
            else
                num = "0";
            return "PTYPE"+num+key;

        }
        //sửa loại sản phẩm
        public bool Update(Ref_Product_Types productType)
        {
            bool status;
            try
            {
                var type = Db.Ref_Product_Types.Find(productType.product_type_code);
                type.product_type_description = productType.product_type_description;
                Db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //xóa loại sản phẩm
        public bool Delete(Ref_Product_Types productType)
        {
            bool status;
            try
            {
                var type = Db.Ref_Product_Types.Find(productType.product_type_code);
                Db.Ref_Product_Types.Remove(type);
                Db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

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
