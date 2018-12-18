using System;
using System.Linq;
using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS.API.Tests
{
    [TestClass]
    public class EventTest
    {
        IEventBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new EventBLL();
        }
        [TestMethod]
        public void TestGetEvents()
        {
            var result = bll.GetEvents(1);
            Assert.AreEqual("TestEvent", result.FirstOrDefault(eventDTO => eventDTO.ConferenceId == 1).Title);
        }
        [TestMethod]
        public void TestGetEventById()
        {
            var result = bll.GetEventById(1);
            Assert.AreEqual("TestEvent", result);
        }
    }
}
