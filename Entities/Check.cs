using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FBPortal.Domain.Entities
{
    public class Check
    {
        public Guid CheckId { get; set; }
        //needs unique index
        [StringLength(50), Required]
        public string Number { get; set; }
        public bool Paid { get; set; }
        public decimal Amount { get; set; }

        public Guid InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }

    }
}
