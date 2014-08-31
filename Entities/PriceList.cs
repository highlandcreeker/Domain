using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBPortal.Domain.Entities
{
    public class PriceList
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public byte[] File { get; set; }

        public string FilePath { get; set; }
        public virtual Client Client { get; set; }
        public virtual Vendor Vendor { get; set; }

        public virtual List<PriceListData> PriceListData { get; set; }
    }
}
