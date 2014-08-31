using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Abstract
{
    public interface IProductRepository
    {
         IQueryable<Product> Products { get; }

        Task<Product> Create(Product product);

        Task<Product> Edit(Product product);

        Task<Product> Delete(Product product);
    }
}
