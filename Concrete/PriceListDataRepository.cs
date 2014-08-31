using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FBPortal.Domain.Abstract;
using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Concrete
{
    public class PriceListDataRepository : IPriceListDataRepository
    {
        private FBPortal.Domain.Concrete.ApplicationDbContext context = new FBPortal.Domain.Concrete.ApplicationDbContext();
        public IQueryable<PriceListData> PriceListData { get { return context.PriceListData; } }
    }
}
