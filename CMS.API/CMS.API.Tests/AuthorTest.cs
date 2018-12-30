using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.API.BLL.BLL;
using System.Linq;
using CMS.API.BLL.Interfaces;

namespace CMS.API.Tests
{
    [TestClass]
    public class AuthorTest
    {
        IAuthorBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new AuthorBLL();
        }

        [TestMethod]
        public void TestGetAuthors()
        {
            var result = bll.GetAuthors();
            Assert.AreEqual(1, result.FirstOrDefault().AuthorId);
        }

        [TestMethod]
        public void TestGetAuthorById()
        {
            var result = bll.GetAuthorById(1);
            Assert.AreEqual(1, result.AuthorId);
            result = bll.GetAuthorById(2);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void TestGetAuthorByAccountId()
        {
            var result = bll.GetAuthorByAccountId(1);
            Assert.AreEqual(1, result.AuthorId);
            result = bll.GetAuthorByAccountId(2);
            Assert.AreEqual(null, result);
        }
    }
}
