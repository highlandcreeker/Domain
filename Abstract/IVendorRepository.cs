using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Abstract
{
    public interface IVendorRepository
    {
        IQueryable<Vendor> Vendors { get; }
        Task<Vendor> Create(Vendor vendor);

        Task<int> Edit(Vendor vendor);

        Task<int> Remove(int id);

    }
}
