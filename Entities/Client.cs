using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FBPortal.Domain.Entities
{
    public class Client
    {
        public Guid ClientId { get; set; }
        [StringLength(256), Required]
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public virtual List<Invoice> Invoices { get; set; }
        public List<ClientPeriod> ClientPeriods { get; set; }

        public Client() { this.Invoices = new List<Invoice>(); }

    }
}
