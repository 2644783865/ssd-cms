using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.API.BLL.BLL;
using System.Linq;
using CMS.API.BLL.Interfaces;

namespace CMS.API.Tests
{
    [TestClass]
    public class EmergencyInfoTest
    {
        IEmergencyInfoBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new EmergencyInfoBLL();
        }

        [TestMethod]
        public void TestGetEmergencyInfoInfo()
        {
            var result = bll.GetEmergencyInfoInfo();
            Assert.AreEqual(1, result.FirstOrDefault().EmergencyInfoId);
        }

        [TestMethod]
        public void TestGetEmergencyInfoById()
        {
            var result = bll.GetEmergencyInfoById(1);
            Assert.AreEqual(1, result.EmergencyInfoId);
            result = bll.GetEmergencyInfoById(2);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestGetEmergencyInfoByConferenceId()
        {
            var result = bll.GetEmergencyInfoByConferenceId(1);
            Assert.AreEqual(1, result.EmergencyInfoId);
            result = bll.GetEmergencyInfoByConferenceId(2);
            Assert.AreEqual(null, result);
        }
    }
}
