﻿using System;
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
            Assert.IsTrue(result.Count()>=1);
        }

        [TestMethod]
        public void TestAssignedBuildingsForConference()
        {
            var result = bll.GetAssignedBuildingsForConference(1);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void TestAvailableRooms1()
        {
            var result = bll.GetAvailableRooms(1, new DateTime(2018, 11, 20, 15, 0, 0), new DateTime(2018, 11, 20, 16, 0, 0), 0);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TestAvailableRooms2()
        {
            var result = bll.GetAvailableRooms(1, new DateTime(2018, 11, 20, 23, 0, 0), new DateTime(2018, 11, 20, 23, 30, 0), 0);
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
            Assert.IsTrue(result.Count()>=3);

        }

        [TestMethod]
        public void TestGetBuildingById()
        {
            var result = bll.GetBuildingById(1);
            Assert.IsNotNull(result);

        }
    }
}
