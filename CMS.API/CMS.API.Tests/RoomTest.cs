using System;
using System.Linq;
using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS.API.Tests
{
    [TestClass]
    public class RoomTest
    {
        IRoomBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new RoomBLL();
        }

        [TestMethod]
        public void TestGetRoomsForBuilding()
        {
            var result = bll.GetRoomsForBuilding(1);
            Assert.AreEqual(1, result.FirstOrDefault(r => r.Code.Equals("123")).RoomID);
        }

        [TestMethod]
        public void TestUnassignedBuildingsForConference()
        {
            var result = bll.GetUnassignedBuildingsForConference(1);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestAssignedBuildingsForConference()
        {
            var result = bll.GetAssignedBuildingsForConference(1);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void TestAvailableRooms()
        {
            var result = bll.GetAvailableRooms(1, new DateTime(2018, 11, 20, 15, 0, 0), new DateTime(2018, 11, 20, 16, 0, 0));
            Assert.AreEqual(2, result.Count());
        }
    }
}
