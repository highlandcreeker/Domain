using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FBPortal.Domain.Entities
{
    [Table("PriceListData")]
    public class PriceListData
    {
        public int ID { get; set; }
        public string ProductNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual PriceList PriceList { get; set; }

    }
}
