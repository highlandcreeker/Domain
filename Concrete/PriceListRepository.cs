using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FBPortal.Domain.Abstract;
using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Concrete
{
    public class PriceListRepository : IPriceListRepository
    {
        private FBPortal.Domain.Concrete.ApplicationDbContext context = new FBPortal.Domain.Concrete.ApplicationDbContext();
        public IQueryable<PriceList> PriceLists { get { return context.PriceLists; } }

        public async Task<PriceList> Create(PriceList pricelist)
        {
            pricelist.DateAdded = DateTime.UtcNow;

            context.PriceLists.Add(pricelist);
            await context.SaveChangesAsync();

            return pricelist;
        }

        public async Task<PriceList> Edit(PriceList pricelist)
        {
            context.Entry(pricelist).State = System.Data.Entity.EntityState.Modified;

            await context.SaveChangesAsync();

            return pricelist;
        }

        public async Task<PriceList> Delete(PriceList pricelist)
        {
            context.PriceLists.Remove(pricelist);

            await context.SaveChangesAsync();

            return pricelist;
        }

        public void AddRange(PriceList[] pricelists)
        {
            context.PriceLists.AddRange(pricelists);
            context.SaveChanges();
        }

    }

}
