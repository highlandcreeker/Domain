using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Abstract
{
    public interface IClientRepository
    {
        IQueryable<Client> Clients { get; }
        Task<Client> Create(Client client);

        Task<int> Edit(Client client);

        Task<int> Remove(Guid id);

        Task<Invoice> CreateInvoice(Invoice clientInvoice);


    }
}
