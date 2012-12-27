using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PermissionsModel.Models;

namespace PermissionsModel._Test
{
    public static class TestFactory
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

        public static Merchant AddMerchant()
        {
         using (var db = new PermissionContext())
         {
             return AddMerchant(db);
         }
        }


        public static Developer AddDeveloper(PermissionContext db)
        {
            var dev = new Developer { Name = "Dev 1" };
            db.Developers.Add(dev);
            db.SaveChanges();
            return db.Developers.First();
        }

        public static Developer AddDeveloper()
        {
            using (var db = new PermissionContext())
            {
                return AddDeveloper(db);
            }
        }
    }
}
