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
            DateTime begin = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime end = new DateTime(2004, 5, 1, 8, 30, 52);
            var result = eventTest.CheckOverlappingEvent(conferenceId, begin, end);
            Assert.AreEqual(false, result.Status);
        }

        [TestMethod]
        public void TestGetEvents()
        {
            var result = eventTest.GetEvents(1);
            Assert.AreEqual("TestEvent", result.FirstOrDefault(eventDTO => eventDTO.EventId == 1).Title);
        }
        [TestMethod]
        public void TestGetEventById()
        {
            var result = eventTest.GetEventById(1);
            Assert.AreEqual("TestEvent", result.Title);
        }
    }
}
