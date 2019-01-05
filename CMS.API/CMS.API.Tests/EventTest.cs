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
        IEventBLL eventTest;

        [TestInitialize]
        public void InitializeBLL()
        {
            eventTest = new EventBLL();
        }

        [TestMethod]
        public void TestCheckEvents()
        {
            int conferenceId = 1;
            DateTime begin = new DateTime(2018, 11, 20, 11, 00, 00);
            DateTime end = new DateTime(2018, 11, 20, 16, 00, 00);
            var result = eventTest.CheckOverlappingEvent(conferenceId, begin, end);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void TestGetEvents()
        {
            var result = eventTest.GetEvents(1);
            Assert.AreEqual("Event Title", result.First().Title);
        }

        [TestMethod]
        public void TestGetEventById()
        {
            var result = eventTest.GetEventById(5);
            Assert.AreEqual("TestEvent", result.Title);
        }
    }
}
