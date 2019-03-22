using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EntityFramework;

namespace Amazon.DAL
{
   public class FooterDAL
    {
        ShopDbContext db = null;

        public ShopDbContext Db { get => db; set => db = value; }
        public FooterDAL()
        {
            Db = new ShopDbContext();
        }
        //Danh sách footer
        public List<Footer> ListFooter()
        {
            return Db.Footers.Where(t=>t.Status == true).ToList();
        }
        //Tạo id tự động
        public int autoKey()
        {
            int key = 0;
            List<Footer> lst = Db.Footers.Select(t => t).ToList<Footer>();
            if (Db.Footers.Count() != 0)
            {
                Footer hv = lst[Db.Footers.Count() - 1];
                key = (hv.FooterID + 1);
            }
            return key;
        }
        //lấy footer
        public Footer ViewDetail(int id)
        {
            return Db.Footers.Find(id);
        }
        //Tạo footer
        public bool Insert(Footer footer)
        {
            Db.Footers.Add(footer);
            Db.SaveChanges();
            return true;
        }
        //sửa footer
        public bool Update(Footer footer)
        {
            bool status;
            try
            {
                var foot = Db.Footers.Find(footer.FooterID);
                foot.FooterID = footer.FooterID;
                foot.Contain = footer.Contain;
                foot.Status = footer.Status;
                foot.FooterIDType = footer.FooterIDType;
                foot.FooterParentID = footer.FooterParentID;
                foot.Link = footer.Link;
                foot.Target = footer.Target;
                Db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        //Xóa footer
        public bool Delete(Footer footer)
        {
            bool status;
            try
            {
                var foot = Db.Footers.Find(footer.FooterID);
                Db.Footers.Remove(foot);
                Db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
