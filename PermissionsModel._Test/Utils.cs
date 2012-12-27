using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermissionsModel.Models;

namespace PermissionsModel._Test
{
    public static class Utils
    {
        public static void ClearDb()
        {
            using (var db = new PermissionContext())
            {
                ClearTable(db.OwnerApps, db);
                ClearTable(db.ResourceOwners, db);
                ClearTable(db.Apps, db);
                ClearTable(db.Merchants, db);
            }

            using (var db = new PermissionContext())
            {
                Assert.AreEqual(0, db.OwnerApps.Count(), "OwnerApps");
                Assert.AreEqual(0, db.Apps.Count(), "OwnerApps");
                Assert.AreEqual(0, db.Developers.Count(), "OwnerApps");
                Assert.AreEqual(0, db.Merchants.Count(), "OwnerApps");
                Assert.AreEqual(0, db.OwnerApps.Count(), "OwnerApps");
                Assert.AreEqual(0, db.ResourceOwners.Count(), "OwnerApps");
            }
        }

        private static void ClearTable<T>(IDbSet<T> table, PermissionContext db) where T : class
        {
            foreach (var row in table.ToArray())
            {
                table.Remove(row);
                db.SaveChanges();
            }
        }
    }
}
