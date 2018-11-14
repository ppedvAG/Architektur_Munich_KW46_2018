using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Zeus.Model;
using ppedv.Zeus.Model.Contracts;

namespace ppedv.Zeus.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetDruckerWithLargestVolume_0_Drucker_in_db_results_null()
        {
            var mock = new Mock<IRepository>();
            var core = new Core(mock.Object);

            var result = core.GetDruckerWithLargestVolume();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Core_GetDruckerWithLargestVolume_2_Drucker_in_db_second_is_larger()
        {
            var d1 = new Drucker() { Hersteller = "D1", MaxX = 3, MaxY = 3, MaxZ = 3 };
            var d2 = new Drucker() { Hersteller = "D2", MaxX = 4, MaxY = 3, MaxZ = 3 };
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Drucker>()).Returns(() =>
            {
                return new[] { d1, d2 };
            });
            var core = new Core(mock.Object);

            var result = core.GetDruckerWithLargestVolume();

            Assert.AreEqual(d2.Hersteller, result.Hersteller);
        }

        [TestMethod]
        public void Core_GetDruckerWithLargestVolume_2_Drucker_in_db_both_same_return_the_older_one()
        {
            var d1 = new Drucker() { Hersteller = "D1", MaxX = 3, MaxY = 3, MaxZ = 3, Created = DateTime.Now };
            var d2 = new Drucker() { Hersteller = "D2", MaxX = 3, MaxY = 3, MaxZ = 3, Created = DateTime.Now.AddMinutes(-1) };
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Drucker>()).Returns(() =>
            {
                return new[] { d1, d2 };
            });
            var core = new Core(mock.Object);

            var result = core.GetDruckerWithLargestVolume();

            Assert.AreEqual(d2.Hersteller, result.Hersteller);
        }
    }
}
