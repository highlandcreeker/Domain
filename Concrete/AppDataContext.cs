using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FBPortal.Domain.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FBPortal.Domain.Concrete
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DataContext")
        {
        }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<ClientPeriod> ClientPeriods { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
    }
}
