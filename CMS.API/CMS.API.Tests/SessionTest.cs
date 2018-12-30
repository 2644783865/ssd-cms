using System;
using System.Linq;
using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.BE.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS.API.Tests
{
    [TestClass]
    public class SessionTest
    {
        ISessionBLL sessionBll;
        IEventBLL eventBll;

        [TestInitialize]
        public void InitializeBLL()
        {
            sessionBll = new SessionBLL();
            eventBll = new EventBLL();
        }

        // Session
        [TestMethod]
        public void TestGetSessions()
        {
            var result = sessionBll.GetSessions(1);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void TestGetSessionById()
        {
            var result = sessionBll.GetSessionByID(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCheckOverlappingSession1()
        {
            // Case 1: Before anything --> should pass
            Response result = sessionBll.CheckOverlappingSession(1, new DateTime(2018, 11, 21, 9, 0, 0), new DateTime(2018, 11, 21, 9, 59, 0), 0);
            Assert.AreEqual(false, result.Status);
        }

        [TestMethod]
        public void TestCheckOverlappingSession2()
        {
            // Case 2: Overlapping with session at the end --> shouldn't pass
            Response result = sessionBll.CheckOverlappingSession(1, new DateTime(2018, 11, 21, 9, 0, 0), new DateTime(2018, 11, 21, 11, 15, 0), 0);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void TestCheckOverlappingSession3()
        {
            // Case 3: Overlapping with session at the beginning --> shouldn't pass
            Response result = sessionBll.CheckOverlappingSession(1, new DateTime(2018, 11, 21, 10, 45, 0), new DateTime(2018, 11, 21, 11, 15, 0), 0);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void TestCheckOverlappingSession4()
        {
            // Case 4: Overlapping with special session at the end --> shouldn't pass
            Response result = sessionBll.CheckOverlappingSession(1, new DateTime(2018, 11, 21, 10, 45, 0), new DateTime(2018, 11, 21, 11, 15, 0), 0);
            Assert.AreEqual(true, result.Status);

        }

        [TestMethod]
        public void TestCheckOverlappingSession5()
        {
            // Case 5: Overlapping with special session at the beginning --> shouldn't pass
            Response result = sessionBll.CheckOverlappingSession(1, new DateTime(2018, 11, 21, 11, 45, 0), new DateTime(2018, 11, 21, 12, 15, 0), 0);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void TestCheckOverlappingSession6()
        {
            // Case 6: Overlapping with event at the end --> shouldn't pass
            Response result = sessionBll.CheckOverlappingSession(1, new DateTime(2018, 11, 20, 12, 45, 0), new DateTime(2018, 11, 20, 13, 15, 0), 0);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void TestCheckOverlappingSession7()
        {
            // Case 7: Overlapping with event at the beginning --> shouldn't pass
            Response result = sessionBll.CheckOverlappingSession(1, new DateTime(2018, 11, 20, 13, 45, 0), new DateTime(2018, 11, 20, 14, 15, 0), 0);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void TestCheckOverlappingSessionForChairman1()
        {
            // Case 1: no overlapping
            Response result = sessionBll.CheckOverlappingSessionForChairman(2, new DateTime(2018, 11, 21, 8, 00, 00), new DateTime(2018, 11, 21, 9, 00, 00), 0, 0);
            Assert.AreEqual(false, result.Status);
        }

        [TestMethod]
        public void TestCheckOverlappingSessionForChairman2()
        {
            // Case 2: overlapping with session in the beginning
            Response result = sessionBll.CheckOverlappingSessionForChairman(2, new DateTime(2018, 11, 21, 9, 45, 00), new DateTime(2018, 11, 21, 10, 15, 00), 0, 0);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void TestCheckOverlappingSessionForChairman3()
        {
            // Case 3: overlapping with session in the end
            Response result = sessionBll.CheckOverlappingSessionForChairman(2, new DateTime(2018, 11, 21, 10, 45, 00), new DateTime(2018, 11, 21, 11, 15, 00), 0, 0);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void TestCheckOverlappingSessionForChairman4()
        {
            // Case 4: overlapping with special session in the beginning
            Response result = sessionBll.CheckOverlappingSessionForChairman(2, new DateTime(2018, 11, 21, 10, 45, 00), new DateTime(2018, 11, 21, 11, 15, 00), 0, 0);
            Assert.AreEqual(true, result.Status);
        }

        [TestMethod]
        public void TestCheckOverlappingSessionForChairman5()
        {
            // Case 1: overlapping with special session in the end
            Response result = sessionBll.CheckOverlappingSessionForChairman(2, new DateTime(2018, 11, 21, 11, 45, 00), new DateTime(2018, 11, 21, 12, 15, 00), 0, 0);
            Assert.AreEqual(true, result.Status);
        }


        // Special Session
        [TestMethod]
        public void TestGetSpecialSessions()
        {
            var result = sessionBll.GetSpecialSessions(1);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestGetSpecialSessionById()
        {
            var result = sessionBll.GetSpecialSessionByID(1);
            Assert.IsNotNull(result);
        }
    }
}
