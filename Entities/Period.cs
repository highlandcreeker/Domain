using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FBPortal.Domain.Entities
{
    public class Period
    {
        public Guid PeriodId { get; set; }
        public int Rank { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       
        public virtual ICollection<Expense> Expense { get; set; }
        public virtual ICollection<ClientPeriod> ClientPeriod { get; set; }

    }
}
