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
            int employeeId = 2;
            DateTime beginDate = new DateTime(2018, 11, 22, 16, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 18, 00, 00);

            /*DateTime beginDate = new DateTime(2018, 11, 22, 14, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 16, 00, 00);

            DateTime beginDate = new DateTime(2018, 11, 22, 12, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 16, 00, 00);

            DateTime beginDate = new DateTime(2018, 11, 22, 12, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 14, 00, 00);

            DateTime beginDate = new DateTime(2018, 11, 22, 10, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 16, 00, 00);

            DateTime beginDate = new DateTime(2018, 11, 22, 10, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 14, 00, 00);

            DateTime beginDate = new DateTime(2018, 11, 22, 10, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 12, 00, 00);

            DateTime beginDate = new DateTime(2018, 11, 22, 9, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 16, 00, 00);

            DateTime beginDate = new DateTime(2018, 11, 22, 9, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 14, 00, 00);

            DateTime beginDate = new DateTime(2018, 11, 22, 9, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 12, 00, 00);

            DateTime beginDate = new DateTime(2018, 11, 22, 9, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 10, 00, 00);

            DateTime beginDate = new DateTime(2018, 11, 22, 8, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 9, 00, 00);*/

            var result = taskTest.CheckOverlappingTask(employeeId, beginDate, endDate);
            Assert.IsTrue(result);
        }
    }
}
