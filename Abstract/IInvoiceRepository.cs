using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Abstract
{
    public interface IInvoiceRepository
    {        
        IQueryable<Invoice> Invoices {get;}

        Task<Invoice> Create(Invoice invoice);

        Task<Invoice> Edit(Invoice invoice);

        Task<Invoice> Delete(Invoice invoice);

   }
}
