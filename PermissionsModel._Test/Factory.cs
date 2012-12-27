using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PermissionsModel.Models;

namespace PermissionsModel._Test
{
    public static class Factory
    {
        public static App AddApp(PermissionContext db)
        {
            var app = new App { ClientKey = "abc", ClientSecret = "def", Description = "Legacy 2 leg app" };
            db.Apps.Add(app);
            db.SaveChanges();
            return db.Apps.First();
        }

        public static Merchant AddMerchant(PermissionContext db)
        {
            var merch1 = new Merchant { Name = "Merch 1" };
            db.Merchants.Add(merch1);
            db.SaveChanges();
            return db.Merchants.First();
        }
    }
}
