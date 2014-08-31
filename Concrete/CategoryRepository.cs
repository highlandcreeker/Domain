using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FBPortal.Domain.Abstract;
using FBPortal.Domain.Entities;

namespace FBPortal.Domain.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IQueryable<Category> Categories { get { return context.Categories.AsQueryable(); } }
    }
}
