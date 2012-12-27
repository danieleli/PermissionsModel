using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PermissionsModel.Models;

namespace PermissionsModel._Test
{
    [TestClass]
    public class AppRepoTest
    {
        private static int _counter = 0;
        private App _testApp;
        readonly AppRepo _repo = new AppRepo();

        [TestInitialize]
        public void Init()
        {
            Utils.ClearDb();
            _testApp = new App { Name = "TestApp" + _counter++ };
        }


        [TestMethod]
        public void NewApp_NoKey_Fails()
        {
            try
            {
                _repo.Save(_testApp);
            }
            catch (DbEntityValidationException dbEx)
            {

                // Todo: refactor to helper method. (throw another exception if not found.)
                bool errFound = false;
                foreach (var results in dbEx.EntityValidationErrors)
                {
                    foreach (var err in results.ValidationErrors)
                    {
                        Debug.WriteLine(err.ErrorMessage);
                        if (err.PropertyName == "ClientKey") errFound = true;
                    }
                }
                if (errFound) return;

                Assert.Fail("Expected validation on property 'ClientKey' not found.");

            }

            Assert.Fail("Expected exception 'DbEntityValidation' not thrown.");

        }

        [TestMethod]
        public void NewApp_NoSecret_Fails()
        {
            _testApp.ClientKey = "key " + _counter;
            _repo.Save(_testApp);
        }

        [TestMethod]
        public void NewApp_NoName_Fails()
        {
            _testApp.ClientKey = "key " + _counter;
            _testApp.ClientKey = "secret " + _counter;
            _repo.Save(_testApp);
        }


        [TestMethod]
        public void NewApp_WithoutMerchantAndDeveloper_Fails()
        {
            _testApp.ClientKey = "key " + _counter;
            _testApp.ClientSecret = "secret " + _counter;

            try
            {
                _repo.Save(_testApp);
            }
            catch (DbEntityValidationException dbEx)
            {

                //todo: throw this exception and populate non-property validation fields.
                Assert.Fail("Expected validation on App object not found.");

            }

            Assert.Fail("Expected exception 'DbEntityValidation' not thrown.");
          
        }


        [TestMethod]
        public void NewApp_WithMerchant_Saves()
        {
            _testApp.ClientKey = "key " + _counter;
            _testApp.ClientKey = "secret " + _counter;

            var merch = TestFactory.AddMerchant();
            _testApp.MerchantId = merch.Id;

            _repo.Save(_testApp);
        }


        [TestMethod]
        public void NewApp_WithDeveloper_Saves()
        {
            _testApp.ClientKey = "key " + _counter;
            _testApp.ClientKey = "secret " + _counter;

            var dev = TestFactory.AddDeveloper();
            _testApp.Developers.Add(dev);

            _repo.Save(_testApp);
        }

        [TestMethod]
        public void NewApp_WithDeveloperAndMerchant_Fails()
        {
            _testApp.ClientKey = "key " + _counter;
            _testApp.ClientKey = "secret " + _counter;

            var dev = TestFactory.AddDeveloper();
            _testApp.Developers.Add(dev);

            var merch = TestFactory.AddMerchant();
            _testApp.MerchantId = merch.Id;

            _repo.Save(_testApp);
        }

    }

    public class AppRepo
    {
        public void Save(App app)
        {
            using (var db = new PermissionContext())
            {
                db.Apps.Add(app);
                db.SaveChanges();
            }
        }
    }
}
