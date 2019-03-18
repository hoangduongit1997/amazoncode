using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public partial class PaymentDTO
    {
        public string payment_id { get; set; }

        public string invoice_number { get; set; }

        public DateTime? payment_date { get; set; }

        public float? payment_amount { get; set; }

        //public virtual InvoiceDTO Invoice { get; set; }
    }
}
