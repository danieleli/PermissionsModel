using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermissionsModel.Models;

namespace PermissionsModel._Test
{
    [TestClass]
    public class LegacyTests
    {

        [TestMethod]
        public void LegacyAppHasOneMerchant()
        {
            Utils.ClearDb();
            int merchId = 0;
            int appId = 0;
            using (var db = new PermissionContext())
            {
                merchId = TestFactory.AddMerchant(db).Id;
                var app1 = TestFactory.AddApp(db);
                appId = app1.Id;
                app1.MerchantId = merchId;
                db.SaveChanges();
            }

            using (var db = new PermissionContext())
            {
                var app = db.Apps.First();
                Assert.AreEqual(appId, app.Id, "AppId");
                Assert.AreEqual(merchId, app.MerchantId, "MerchId");
                Assert.IsNotNull(app.Merchant, "Merchant is null");
            }

        }
    }
}
