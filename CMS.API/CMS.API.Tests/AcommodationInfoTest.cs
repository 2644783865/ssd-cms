using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.API.BLL.BLL;
using System.Linq;
using CMS.API.BLL.Interfaces;

namespace CMS.API.Tests
{
    [TestClass]
    public class AccommodationInfoTest
    {
        IAccommodationInfoBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new AccommodationInfoBLL();
        }

        [TestMethod]
        public void TestGetAccommodationInfoInfo()
        {
            var result = bll.GetAccommodationInfoInfo();
            Assert.AreEqual(1, result.FirstOrDefault().ConferenceId);
        }

        [TestMethod]
        public void TestGetAccommodationInfoById()
        {
            var result = bll.GetAccommodationInfoById(1);
            Assert.AreEqual("No City", result.City);
            result = bll.GetAccommodationInfoById(0);
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void TestGetAccommodationInfoByConferenceId()
        {
            var result = bll.GetAccommodationInfoByConferenceId(1);
            Assert.AreEqual(1, result.FirstOrDefault().AccommodationInfoId);
            result = bll.GetAccommodationInfoByConferenceId(0);
            Assert.AreEqual(null, result.FirstOrDefault());
        }
    }
}
