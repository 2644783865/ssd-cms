using CMS.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CMS.Core.Tests
{
    [TestClass]
    public class HelpersTests
    {
        [TestMethod]
        public void TestEmail()
        {
            Assert.AreEqual(true, ConstraintHelper.ValidateEmail("test@cms.com"));
            Assert.AreEqual(false, ConstraintHelper.ValidateEmail("t@c.c"));
            Assert.AreEqual(false, ConstraintHelper.ValidateEmail("testcms.com"));
            Assert.AreEqual(false, ConstraintHelper.ValidateEmail("@cms.com"));
            Assert.AreEqual(false, ConstraintHelper.ValidateEmail("test@.com"));
            Assert.AreEqual(false, ConstraintHelper.ValidateEmail("test@cmscom"));
            Assert.AreEqual(false, ConstraintHelper.ValidateEmail("test@cms."));
            Assert.AreEqual(false, ConstraintHelper.ValidateEmail("testcmscom"));
        }

        [TestMethod]
        public void TestPhoneNumber()
        {
            Assert.AreEqual(true, ConstraintHelper.ValidatePhoneNumber("0123456789"));
            Assert.AreEqual(true, ConstraintHelper.ValidatePhoneNumber("0 123 456 789"));
            Assert.AreEqual(true, ConstraintHelper.ValidatePhoneNumber("+48 012 345 6789"));
            Assert.AreEqual(false, ConstraintHelper.ValidatePhoneNumber("0123t456789"));
            Assert.AreEqual(false, ConstraintHelper.ValidatePhoneNumber("test"));
        }
    }
}
