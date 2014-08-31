using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FBPortal.Domain.Abstract;
using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private FBPortal.Domain.Concrete.ApplicationDbContext context = new FBPortal.Domain.Concrete.ApplicationDbContext();
        public IQueryable<Product> Products { get { return context.Products; } }

        public async Task<Product> Create(Product product)
        {
            product.DateAdded = DateTime.UtcNow;

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Edit(Product product)
        {
            context.Entry(product).State = System.Data.Entity.EntityState.Modified;

            await context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            context.Products.Remove(product);

            await context.SaveChangesAsync();

            return product;
        }

        public void AddRange(Product[] products)
        {
            context.Products.AddRange(products);
            context.SaveChanges();
        }

    }



}
