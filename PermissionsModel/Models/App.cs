using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionsModel.Models
{
    public class PermissionContext : DbContext
    {
        public DbSet<App> Apps { get; set; }    
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<ResourceOwner> ResourceOwners { get; set; }
        public DbSet<OwnerApp> OwnerApps { get; set; }
    }


    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class App : BaseModel
    {
        public App()
        {
            this.Developers = new List<Developer>();
        }
        [Required]
        public string ClientKey { get; set; }
        [Required]
        public string ClientSecret { get; set; }
        public int? MerchantId { get; set; }
        public virtual Merchant Merchant { get; set; }
        public virtual List<Developer> Developers { get; set; }
    }

    public class Developer : BaseModel
    {
        public virtual List<App> Apps { get; set; }
    }

    public class Merchant : BaseModel
    {
        public virtual List<ResourceOwner> ResourceOwners { get; set; }
        public virtual List<OwnerApp> OwnerApps { get; set; }
    }

    public class ResourceOwner : BaseModel
    {
        public virtual List<Merchant> Merchants { get; set; }
        public virtual List<OwnerApp> MyApps { get; set; }
    }

    public class OwnerApp : BaseModel
    {
        public string AppToken { get; set; }
        public int AppId { get; set; }
        public virtual App App { get; set; }
        public int OwnerId { get; set; }
        public virtual ResourceOwner Owner { get; set; }
        public virtual List<Merchant> Merchants { get; set; }
    }
}
