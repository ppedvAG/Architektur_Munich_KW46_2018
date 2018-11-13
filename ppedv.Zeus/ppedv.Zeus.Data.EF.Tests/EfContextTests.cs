using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Zeus.Model;

namespace ppedv.Zeus.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_Database()
        {
            using (var con = new EfContext())
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                Assert.IsFalse(con.Database.Exists());
                con.Database.Create();
                Assert.IsTrue(con.Database.Exists());
            }
        }

        [TestMethod]
        public void EfContext_can_insert_and_read_Drucker()
        {
            var testDrucker = new Drucker();
            testDrucker.Hersteller = "Binford";

            using (var con = new EfContext())
            {
                con.Drucker.Add(testDrucker);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Drucker.Find(testDrucker.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(testDrucker.Hersteller, loaded.Hersteller);
            }
        }
    }
}
