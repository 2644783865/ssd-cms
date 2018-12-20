using System.Linq;
using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CMS.API.Tests
{
    [TestClass]
    public class AwardTest
    {
        IAwardBLL awardTests;

        [TestInitialize]
        public void InitializeBLL()
        {
            awardTests = new AwardBLL();
        }

        [TestMethod]
        public void TestGetAwards()
        {
            var result = awardTests.GetAwards();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetAwardById()
        {
            int id = 1;
            var result = awardTests.GetAwardById(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestCheckIfPresentationHasAward()
        {
            int presentationId = 1;
            var result = awardTests.CheckIfPresentationHasAward(presentationId);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestDeleteAssignmentAwardToPresentation()
        {
            int presentationId = 1;
            var result = awardTests.DeleteAssignmentAwardToPresentation(presentationId);
            Assert.AreEqual(false, result);
        }
    }
}
