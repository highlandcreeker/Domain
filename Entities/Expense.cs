using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FBPortal.Domain.Entities
{
    public class Expense
    {
        public Guid ExpenseId { get; set; }
        public decimal CostofGoodsSold { get; set; }
        public decimal SalariesAndWages { get; set; }
        public decimal DirectOperating { get; set; }
        public decimal Marketing { get; set; }
        public decimal Utilities { get; set; }
        public decimal Occupancy { get; set; }
        public decimal Maintenance { get; set; }
        public decimal Administrative { get; set; }
        public decimal CorporateOverhead { get; set; }

        [ForeignKey("Period")]
        public Guid PeriodId { get; set; }
        public virtual Period Period { get; set; }
    }
}
