using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public partial class Ref_Invoice_Status_CodesDTO
    {
        //public Ref_Invoice_Status_CodesDTO()
        //{
        //    Invoices = new HashSet<InvoiceDTO>();
        //}

        public int invoice_status_code { get; set; }

        public string invoice_status_description { get; set; }

        //public virtual ICollection<InvoiceDTO> Invoices { get; set; }
    }
}
