using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Abstract
{
    public interface IPriceListRepository
    {
        IQueryable<PriceList> PriceLists { get; }

        Task<PriceList> Create(PriceList pricelist);
        Task<PriceList> Edit(PriceList pricelist);

        Task<PriceList> Delete(PriceList pricelist);
    }
}
