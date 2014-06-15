using System;
using Microsoft.AspNet.Identity.EntityFramework;


namespace FBPortal.Domain.Entities
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
    }

  
}