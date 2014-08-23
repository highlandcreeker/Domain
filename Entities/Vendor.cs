using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FBPortal.Domain.Entities
{
    public class Vendor
    {
        public int ID { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public string Description { get; set; }

        
        public DateTime DateAdded { get; set; }

        public virtual List<Product> Products { get; set; }

    }
}
