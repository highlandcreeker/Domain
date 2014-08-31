using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FBPortal.Domain.Abstract;
using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Concrete
{
    public class VendorRepository : IVendorRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IQueryable<Vendor> Vendors { get { return context.Vendors.AsQueryable(); } }

        public async Task<Vendor> Create(Vendor vendor)
        {
            vendor.DateAdded = DateTime.UtcNow;

            context.Vendors.Add(vendor);
            await context.SaveChangesAsync();

            return vendor;
        }
        public async Task<int> Edit(Vendor vendor)
        {
            context.Entry(vendor).State = System.Data.Entity.EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        public async Task<int> Remove(int id)
        {
            Vendor vendor = await context.Vendors.FindAsync(id);
            context.Vendors.Remove(vendor);
            return await context.SaveChangesAsync();
        }

    }
}
