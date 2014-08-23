using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBPortal.Domain.Abstract;
using FBPortal.Domain.Entities;


namespace FBPortal.Domain.Concrete
{
    public class InvoiceRepository : IInvoiceRepository, IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IQueryable<Invoice> Invoices { get { return context.Invoices; } }

        public async Task<Invoice> Create(Invoice invoice)
        {
            invoice.InvoiceId = Guid.NewGuid();
            context.Invoices.Add(invoice);

            await context.SaveChangesAsync();

            return invoice;
        }

        public async Task<Invoice> Edit(Invoice invoice)
        {
            Invoice edit = context.Invoices.Where(i => i.InvoiceId == invoice.InvoiceId).FirstOrDefault();

            edit.Name = invoice.Name;
            edit.Vendor = invoice.Vendor;
            edit.AmountPaid = invoice.AmountPaid;

            await context.SaveChangesAsync();

            return invoice;
        }

        public async Task<Invoice> Delete(Invoice invoice)
        {
            context.Invoices.Remove(invoice);

            await context.SaveChangesAsync();

            return invoice;
        }

        // Flag: Has Dispose already been called? 
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }

    }
}
