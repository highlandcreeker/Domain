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
        private FBPortal.Domain.Concrete.ApplicationDbContext dbContext = new FBPortal.Domain.Concrete.ApplicationDbContext();
        public IQueryable<Product> Products { get { return dbContext.Products; } }

        public async Task<Product> Create(Product product)
        {
            product.DateAdded = DateTime.UtcNow;

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();

            return product;
        }

        public void AddRange(Product[] products)
        {
            dbContext.Products.AddRange(products);
            dbContext.SaveChanges();
        }

    }



}
