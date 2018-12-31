using System.Linq;
using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CMS.API.Tests
{
    [TestClass]
    public class TaskTest
    {
        ITaskBLL taskTest;

        [TestInitialize]
        public void InitializeBLL()
        {
            taskTest = new TaskBLL();
        }

        [TestMethod]
        public void TestGetTasks()
        {
            int ConferenceId = 1;
            var result = taskTest.GetTasks(ConferenceId);
            Assert.AreEqual("TestTask", result.FirstOrDefault(task => task.ConferenceId == ConferenceId).Title);
        }

        [TestMethod]
        public void TestGetTaskById()
        {
            int id = 1;
            var result = taskTest.GetTaskById(id);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestGetTasksForEmployee()
        {
            int EmployeeId = 1;
            int ConferenceId = 1;
            var result = taskTest.GetTasksForEmployee(EmployeeId, ConferenceId);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetTasksByConferenceId()
        {
            int ConferenceId = 1;
            var result = taskTest.GetTasksByConferenceId(ConferenceId);
            Assert.IsNotNull(result);             
        }

        [TestMethod]
        public void TestCheckOverlappingTask()
        {
            int employeeId = 1;
            DateTime beginDate = new DateTime(2008, 5, 1, 8, 30, 52);
            DateTime endDate = new DateTime(2004, 5, 1, 8, 30, 52);
            var result = taskTest.CheckOverlappingTask(employeeId, beginDate, endDate);
            Assert.IsFalse(result);
        }
    }
}
