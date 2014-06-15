using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using System.Xml.Linq;

namespace FBPortal.Domain.Entities
{
    public class ClientPeriod
    {
        public Guid ClientPeriodId { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal Balance { get; set; }

        [ForeignKey("Period")]
        public Guid PeriodId { get; set; }
        public virtual Period Period { get; set; }

        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

    }
}
