using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FBPortal.Domain.Entities
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DateAdded { get; set; }

        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

    }
}
