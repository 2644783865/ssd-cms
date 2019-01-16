using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.API.BLL.BLL;
using System.Linq;
using CMS.API.BLL.Interfaces;

namespace CMS.API.Tests
{
    [TestClass]
    public class ReviewTest
    {
        IReviewBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new ReviewBLL();
        }

        [TestMethod]
        public void TestGetReviewInfo()
        {
            var result = bll.GetReviewInfo(1);
            Assert.AreEqual(1, result.FirstOrDefault().ReviewId);
        }

        [TestMethod]
        public void TestGetReviewById()
        {
            var result = bll.GetReviewById(1);
            Assert.AreEqual(1, result.ReviewId);
            result = bll.GetReviewById(0);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestGetAuthorByArticleId()
        {
            var result = bll.GetReviewsByArticleId(1);
            Assert.AreEqual(1, result.FirstOrDefault().ReviewId);
            result = bll.GetReviewsByArticleId(2);
            Assert.AreEqual(null, result.FirstOrDefault());
        }
    }
}
