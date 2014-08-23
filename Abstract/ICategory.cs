using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Abstract
{
    public interface ICategory
    {
        IQueryable<Category> Categories { get; }
    }
}
