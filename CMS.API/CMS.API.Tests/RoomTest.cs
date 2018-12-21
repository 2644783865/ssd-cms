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

        [TestMethod]
        public void TestGetRoomById()
        {
            var result = bll.GetRoomById(1);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestGetBuildings()
        {
            var result = bll.GetBuildings();
            Assert.AreEqual(3, result.Count());

        }

        [TestMethod]
        public void TestGetBuildingById()
        {
            var result = bll.GetBuildingById(1);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestSetBuildingForConference()
        {
            var result = bll.SetBuildingForConference(1, 2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDeleteAssignmentBuildingForConference()
        {
            var result = bll.DeleteAssignmentBuildingForConference(1, 2);
            Assert.IsTrue(result);
        }
    }
}
