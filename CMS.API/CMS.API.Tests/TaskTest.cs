using System;
using System.Linq;
using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS.API.Tests
{
    [TestClass]
    public class TaskTest
    {
        ITaskBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new TaskBLL();
        }
        [TestMethod]
        public void TestGetTasks()
        {
            var result = bll.GetTasks(1);
            Assert.AreEqual("TestTask", result.FirstOrDefault(task => task.ConferenceId == 1).Title);
        }
        [TestMethod]
        public void TestGetTaskById()
        {
            var result = bll.GetTaskById(1);
            Assert.AreEqual("TestTask", result);
        }

    }
}
