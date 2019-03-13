using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DAL;
using Amazon.EntityFramework;
using PagedList;

namespace Amazon.BUS
{
    public class ProductTypeBUS
    {
        ProductTypeDAL da = new ProductTypeDAL();

        public ProductTypeDAL Da { get => da; set => da = value; }

        public Ref_Product_Types ViewDetail(string id)
        {
            return Da.ViewDetail(id);
        }

        public string Insert(Ref_Product_Types productType)
        {
            return Da.Insert(productType);
        }

        public bool Update(Ref_Product_Types productType)
        {
            return Da.Update(productType);
        }

        public bool Delete(string id)
        {
            return Da.Delete(id);
        }

        public IEnumerable<Ref_Product_Types> ListAll(int page, int pageSize)
        {
            return Da.ListAllPaging(page, pageSize);
        }
        public List<Ref_Product_Types> ListAllProductType()
        {
            return Da.ListAllProductType();
        }
    }
}
