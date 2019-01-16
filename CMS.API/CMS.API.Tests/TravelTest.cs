using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.API.BLL.BLL;
using System.Linq;
using CMS.API.BLL.Interfaces;

namespace CMS.API.Tests
{
    [TestClass]
    public class TravelTest
    {
        ITravelBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new TravelBLL();
        }

        [TestMethod]
        public void TestGetTravelInfo()
        {
            var result = bll.GetTravelInfo();
            Assert.AreEqual(1, result.FirstOrDefault().TravelInfoId);
        }

        [TestMethod]
        public void TestGetTravelById()
        {
            var result = bll.GetTravelById(1);
            Assert.AreEqual(1, result.TravelInfoId);
            result = bll.GetTravelById(0);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestGetTravelInfoByConferenceId()
        {
            var result = bll.GetTravelInfoByConferenceId(1);
            Assert.AreEqual(1, result.FirstOrDefault().TravelInfoId);
            result = bll.GetTravelInfoByConferenceId(0);
            Assert.AreEqual(null, result.FirstOrDefault());
        }
    }
}
