using System.Linq;
using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var result = taskTest.GetTasks(1);
            Assert.AreEqual("TestTask", result.FirstOrDefault(task => task.ConferenceId == 1).Title);
        }

        [TestMethod]
        public void TestGetTaskById()
        {
            var result = taskTest.GetTaskById(1);
            Assert.AreNotEqual(null, result);
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
    }
}
