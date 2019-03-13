using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DAL;
using Amazon.EntityFramework;

namespace Amazon.BUS
{
   public class FooterBUS
    {
        FooterDAL footer = null;

        public FooterDAL Footer { get => footer; set => footer = value; }
        public FooterBUS()
        {
            Footer = new FooterDAL();
        }
        public List<Footer> ListFooterBUS()
        {
            return Footer.ListFooter().ToList();
        }
    }
}
