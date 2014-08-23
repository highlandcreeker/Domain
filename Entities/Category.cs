using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FBPortal.Domain.Entities
{
    public class Category
    {
        public int ID { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
    }
}
