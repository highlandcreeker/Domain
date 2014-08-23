using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FBPortal.Domain.Entities
{
    public enum EPackageType
    {
        LB = 0,
        LBA = 1,
        LBPlus = 2,
        OZ = 3,
        OZA = 4
    }

    public class Product
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string Number { get; set; }

        public string Description { get; set; }

        [MaxLength(256)]
        public string Brand { get; set; }

        public int Quantity { get; set; }

        public decimal Weight { get; set; }

        public EPackageType PackageTypeCode { get; set; }

        [MaxLength(8)]
        public string PackageType { get; set; }

        public decimal Price { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual Category Category { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
