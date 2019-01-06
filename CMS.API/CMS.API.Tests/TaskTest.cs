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
            Assert.AreEqual("TestTask", result.Title);
        }

        [TestMethod]
        public void TestGetTasksForEmployee()
        {
            int EmployeeId = 2;
            int ConferenceId = 1;
            var result = taskTest.GetTasksForEmployee(EmployeeId, ConferenceId);
            Assert.AreEqual("TestTask", result.First().Title);
        }

        [TestMethod]
        public void TestGetTasksByConferenceId()
        {
            int ConferenceId = 1;
            var result = taskTest.GetTasksByConferenceId(ConferenceId);
            Assert.AreEqual("TestTask", result.First().Title);             
        }

        [TestMethod]
        public void TestCheckOverlappingTask()
        {
            int employeeId = 2;
          
            DateTime beginDate = new DateTime(2018, 11, 22, 16, 00, 00);
            DateTime endDate = new DateTime(2018, 11, 22, 18, 00, 00);
            var result = taskTest.CheckOverlappingTask(employeeId, beginDate, endDate);
            Assert.IsTrue(result);
            
            DateTime beginDate1 = new DateTime(2018, 11, 22, 14, 00, 00);
            DateTime endDate1 = new DateTime(2018, 11, 22, 16, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate1, endDate1);
            Assert.IsTrue(result);
            
            DateTime beginDate2 = new DateTime(2018, 11, 22, 12, 00, 00);
            DateTime endDate2 = new DateTime(2018, 11, 22, 16, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate2, endDate2);
            Assert.IsFalse(result);

            DateTime beginDate3 = new DateTime(2018, 11, 22, 12, 00, 00);
            DateTime endDate3 = new DateTime(2018, 11, 22, 14, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate3, endDate3);
            Assert.IsFalse(result);

            DateTime beginDate4 = new DateTime(2018, 11, 22, 10, 00, 00);
            DateTime endDate4 = new DateTime(2018, 11, 22, 16, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate4, endDate4);
            Assert.IsFalse(result);

            DateTime beginDate5 = new DateTime(2018, 11, 22, 10, 00, 00);
            DateTime endDate5 = new DateTime(2018, 11, 22, 14, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate5, endDate5);
            Assert.IsFalse(result);

            DateTime beginDate6 = new DateTime(2018, 11, 22, 10, 00, 00);
            DateTime endDate6 = new DateTime(2018, 11, 22, 12, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate6, endDate6);
            Assert.IsFalse(result);

            DateTime beginDate7 = new DateTime(2018, 11, 22, 9, 00, 00);
            DateTime endDate7 = new DateTime(2018, 11, 22, 16, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate7, endDate7);
            Assert.IsFalse(result);

            DateTime beginDate8 = new DateTime(2018, 11, 22, 9, 00, 00);
            DateTime endDate8 = new DateTime(2018, 11, 22, 14, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate8, endDate8);
            Assert.IsFalse(result);

            DateTime beginDate9 = new DateTime(2018, 11, 22, 9, 00, 00);
            DateTime endDate9 = new DateTime(2018, 11, 22, 12, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate9, endDate9);
            Assert.IsFalse(result);

            DateTime beginDate10 = new DateTime(2018, 11, 22, 9, 00, 00);
            DateTime endDate10 = new DateTime(2018, 11, 22, 10, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate10, endDate10);
            Assert.IsTrue(result);

            DateTime beginDate11 = new DateTime(2018, 11, 22, 8, 00, 00);
            DateTime endDate11 = new DateTime(2018, 11, 22, 9, 00, 00);
            result = taskTest.CheckOverlappingTask(employeeId, beginDate11, endDate11);
            Assert.IsTrue(result);
        }
    }
}
