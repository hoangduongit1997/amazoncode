using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.DTO
{
    public partial class InvoiceDTO
    {
        //public InvoiceDTO()
        //{
        //    Payments = new HashSet<PaymentDTO>();
        //    Shipments = new HashSet<ShipmentDTO>();
        //}

        public string invoice_number { get; set; }

        public string order_id { get; set; }

        public DateTime? invoice_date { get; set; }

        public int? invoice_status_code { get; set; }

        public float? invoice_total_money { get; set; }

        //public virtual OrderDTO Order { get; set; }

        //public virtual Ref_Invoice_Status_CodesDTO Ref_Invoice_Status_Codes { get; set; }

        //public virtual ICollection<PaymentDTO> Payments { get; set; }

        //public virtual ICollection<ShipmentDTO> Shipments { get; set; }
    }
}
