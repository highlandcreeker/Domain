namespace FBPortal.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FBPortal.Domain.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<FBPortal.Domain.Concrete.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FBPortal.Domain.Concrete.ApplicationDbContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            ////
            context.Clients.AddOrUpdate(new Client { ClientId = new Guid("1D34E30D-4C11-4FFF-9C31-C025126F15CA"), Name = "Midtown Bar and Grille" });
            context.Clients.AddOrUpdate(new Client { ClientId = new Guid("8FD19931-154F-43D3-B676-D06B9A398A6E"), Name = "Moes Crosstown" });

            context.Invoices.AddOrUpdate(new Invoice { InvoiceId = Guid.NewGuid(), Name = "Vegetables", Vendor = "Sysco", ClientId = new Guid("8FD19931-154F-43D3-B676-D06B9A398A6E"), AmountPaid = 225.36M, DateAdded = DateTime.Now });
            context.Invoices.AddOrUpdate(new Invoice { InvoiceId = Guid.NewGuid(), Name = "Meat", Vendor = "US Foods", ClientId = new Guid("8FD19931-154F-43D3-B676-D06B9A398A6E"), AmountPaid = 564.36M, DateAdded = DateTime.Now });
            context.Invoices.AddOrUpdate(new Invoice { InvoiceId = Guid.NewGuid(), Name = "Fruit", Vendor = "Sysco", ClientId = new Guid("8FD19931-154F-43D3-B676-D06B9A398A6E"), AmountPaid = 201.36M, DateAdded = DateTime.Now });

            context.Invoices.AddOrUpdate(new Invoice { InvoiceId = Guid.NewGuid(), Name = "Meat", Vendor = "Sysco", ClientId = new Guid("1D34E30D-4C11-4FFF-9C31-C025126F15CA"), AmountPaid = 596.32M, DateAdded = DateTime.Now });
            context.Invoices.AddOrUpdate(new Invoice { InvoiceId = Guid.NewGuid(), Name = "Fruit", Vendor = "US Foods", ClientId = new Guid("1D34E30D-4C11-4FFF-9C31-C025126F15CA"), AmountPaid = 287.96M, DateAdded = DateTime.Now });

            RoleManager<IdentityRole> rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityRole adminRole = new IdentityRole { Name = "Administrator" };
            IdentityRole userRole = new IdentityRole { Name = "User" };

            if (!rm.RoleExists(adminRole.Name)) { rm.Create<IdentityRole>(adminRole); }
            if (!rm.RoleExists(userRole.Name)) { rm.Create<IdentityRole>(userRole); }

            UserManager<ApplicationUser> um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser admin = new ApplicationUser { UserName = "admin", Id = Guid.NewGuid().ToString(), ClientId = new Guid("1D34E30D-4C11-4FFF-9C31-C025126F15CA") };

            string password = "123456";
            IdentityResult result = null;

            if (um.Find(admin.UserName, password) != null)
            {
                result = um.Create(admin, password);

                if (result.Succeeded)
                {
                    um.AddToRole<ApplicationUser>(admin.Id, "Administrator");
                }
            }

            ApplicationUser user = new ApplicationUser { UserName = "user", Id = Guid.NewGuid().ToString(), ClientId = new Guid("1D34E30D-4C11-4FFF-9C31-C025126F15CA") };

            if (um.Find(user.UserName, password) != null)
            {
                result = um.Create(user, password);

                if (result.Succeeded)
                {
                    um.AddToRole<ApplicationUser>(user.Id, "User");
                }
            }

        }

    }
}
