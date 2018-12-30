using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.API.BLL.BLL;
using System.Linq;
using CMS.API.BLL.Interfaces;

namespace CMS.API.Tests
{
    [TestClass]
    public class WelcomePackTest
    {
        IWelcomePackBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new WelcomePackBLL();
        }

        [TestMethod]
        public void TestGetWelcomePackReceiverInfo()
        {
            var result = bll.GetWelcomePackReceiverInfo();
            Assert.AreEqual(1, result.FirstOrDefault().WelcomePackReceiverId);
        }

        [TestMethod]
        public void TestGetWelcomePackReceiverById()
        {
            var result = bll.GetWelcomePackReceiverById(1);
            Assert.AreEqual(1, result.WelcomePackReceiverId);
            result = bll.GetWelcomePackReceiverById(2);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestGetGuestsByConferenceId()
        {
            var result = bll.GetGuestsByConferenceId(1);
            Assert.AreEqual(1, result.FirstOrDefault().ConferenceId);
            result = bll.GetGuestsByConferenceId(2);
            Assert.AreEqual(null, result.FirstOrDefault());
        }
    }
}
