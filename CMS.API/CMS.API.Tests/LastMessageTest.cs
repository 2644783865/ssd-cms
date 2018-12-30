using System;
using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS.API.Tests
{
    [TestClass]
    public class LastMessageTest
    {
        ILastMessageBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new LastMessageBLL();
        }
        
        [TestMethod]
        public void TestGetLastMessageByPairId()
        {
            var result = bll.GetLastMessageByPairId(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetLastMessageByFirstId()
        {
            var result = bll.GetLastMessageByFirstId(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetLastMessageBySecondId()
        {
            var result = bll.GetLastMessageBySecondId(2);
            Assert.IsNotNull(result);
        }
    }
} 
