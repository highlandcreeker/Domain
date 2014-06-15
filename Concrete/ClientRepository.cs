using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBPortal.Domain.Abstract;
using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Concrete
{
    public class ClientRepository : IClientRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IQueryable<Client> Clients { get { return context.Clients.AsQueryable(); } }
               
        public async Task<Client> Create(Client client)
        {
            client.ClientId = Guid.NewGuid();
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            return client;
        }
        public async Task<int> Edit(Client client)
        {
            context.Entry(client).State = System.Data.Entity.EntityState.Modified;
            return await context.SaveChangesAsync();
        }

        public async Task<int> Remove(Guid id)
        {
            Client client = await context.Clients.FindAsync(id);
            context.Clients.Remove(client);
            return await context.SaveChangesAsync();
        }

        public async Task<Invoice> CreateInvoice(Invoice clientInvoice)
        {
            clientInvoice.InvoiceId = Guid.NewGuid();
            context.Invoices.Add(clientInvoice);

            Client client = context.Clients.Where(c => c.ClientId == clientInvoice.ClientId).FirstOrDefault();
            client.Balance -= clientInvoice.AmountPaid;
            
            await context.SaveChangesAsync();

            return clientInvoice;
        }

    }
}
