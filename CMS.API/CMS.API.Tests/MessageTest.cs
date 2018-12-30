using System;
using System.Linq;
using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS.API.Tests
{
    [TestClass]
    public class MessageTest
    {
        IMessageBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new MessageBLL();
        }

        [TestMethod]
        public void TestGetMessages()
        {
            var result = bll.GetMessages();
            Assert.AreEqual(1, result.Count());
        }
        
    public void TestGetMessagesBySenderId1()
        {
            var result = bll.GetMessagesBySenderId(1);
            Assert.AreEqual(1, result.Count());
        }
        
        [TestMethod]
        public void TestGetMessagesBySenderId2()
        {
            var result = bll.GetMessagesBySenderId(1);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetMessagesByReceiverId1()
        {
            var result = bll.GetMessagesByReceiverId(2);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestGetMessagesByReceiverId2()
        {
            var result = bll.GetMessagesByReceiverId(1);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGetMessageById()
        {
            var result = bll.GetMessageById(1);
            Assert.IsNotNull(result);
        }
    }
}
