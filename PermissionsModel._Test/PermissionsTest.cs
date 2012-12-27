using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermissionsModel.Models;

namespace PermissionsModel._Test
{
    [TestClass]
    public class PermissionsTest
    {
        [TestMethod]
        public void GetApps()
        {
            using (var db = new PermissionContext())
            {
                var apps = db.Apps.ToArray();
                foreach (var app in apps)
                {
                    Debug.WriteLine(app.Id + " - " + app.Name);
                }

                Assert.IsTrue(apps.Count()>0, "App count > 0.");
            }
        }

        [TestMethod]
        public void GetDevelopers()
        {
            using (var db = new PermissionContext())
            {
                var devs = db.Developers.ToArray();
                foreach (var developer in devs)
                {
                    Debug.WriteLine(developer.Id + " - " + developer.Name);
                }

                Assert.IsTrue(devs.Count() > 0, "Dev count > 0.");
            }
        }

        //[TestMethod]
        //public void AssociateEntities()
        //{
        //    using (var db = new PermissionContext())
        //    {
        //        var devs = db.Developers.ToArray();
        //        var apps = db.Apps.ToArray();
        //        var merchs = db.Merchants.ToArray();
        //        var owners = db.ResourceOwners.ToArray();

        //        //apps[4].Merchant = merchs[3];
        //        //devs[0].Apps.Add(apps[0]);
        //        //devs[0].Apps.Add(apps[1]);
        //        //devs[1].Apps.Add(apps[2]);
        //        //devs[3].Apps.Add(apps[0]);
        //        db.SaveChanges();
        //    }
        //}


        [TestMethod]
        public void Dev1Has2Apps()
        {
            using (var db = new PermissionContext())
            {
                var dev1 = db.Developers.Single(d => d.Id == 1);
                Assert.AreEqual(2, dev1.Apps.Count(), "Dev1.Apps.Count count =2.");
            }
        }

        [TestMethod]
        public void Dev2Has1Apps()
        {
            using (var db = new PermissionContext())
            {
                var dev2 = db.Developers.Single(d => d.Id == 2);
                Assert.AreEqual(1, dev2.Apps.Count(), "Dev2.Apps.Count count =2.");
            }
        }

        [TestMethod]
        public void Dev3Has0Apps()
        {
            using (var db = new PermissionContext())
            {
                var dev3 = db.Developers.Single(d => d.Id == 3);
                Assert.AreEqual(0, dev3.Apps.Count(), "Dev3.Apps.Count count =0.");
            }
        }

        [TestMethod]
        public void App19Has2Devs()
        {
            using (var db = new PermissionContext())
            {
                var app1 = db.Apps.Single(a => a.Id == 19);
                Assert.AreEqual(2, app1.Developers.Count(), "App19.Devs.Count count =2.");
            }
        }

        [TestMethod]
        public void App20Has1Devs()
        {
            using (var db = new PermissionContext())
            {
                var app2 = db.Apps.Single(a => a.Id == 20);
                Assert.AreEqual(1, app2.Developers.Count(), "App20.Devs.Count count =2.");
            }
        }

        [TestMethod]
        public void App21Has1Devs()
        {
            using (var db = new PermissionContext())
            {
                var app3 = db.Apps.Single(a => a.Id == 21);
                Assert.AreEqual(1, app3.Developers.Count(), "App21.Devs.Count count =0.");
            }
        }
    }
}
