using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.API.BLL.Models.Authentication;
using CMS.API.BLL.BLL.Authentication;
using CMS.API.DAL;
using System.Linq;
using CMS.API.BLL.Interfaces.Authentication;

namespace CMS.API.Tests
{
    [TestClass]
    public class AuthenticationTest
    {
        IAuthenticationBLL bll;

        [TestInitialize]
        public void InitializeBLL()
        {
            bll = new AuthenticationBLL();
        }
       
        [TestMethod]
        public void TestLogin()
        {
            var loginModel = new LoginModel()
            {
                Login = "testlogin",
                Password = "testpass"
            };
            var result = bll.Login(loginModel);
            Assert.AreEqual(1, result);
            loginModel = new LoginModel()
            {
                Login = "testlogin",
                Password = "wrong password"
            };
            result = bll.Login(loginModel);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestCheckCredentials()
        {
            var loginModel = new LoginModel()
            {
                Login = "testlogin",
                Password = "testpass"
            };
            var result = bll.CheckCredentials(loginModel);
            Assert.AreEqual(true, result);
            loginModel = new LoginModel()
            {
                Login = "testuser",
                Password = "wrong password"
            };
            result = bll.CheckCredentials(loginModel);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestChangePassword()
        {
            var changePasswordModel = new ChangePasswordModel()
            {
                Login = "testlogin",
                Password = "testpass",
                NewPassword = "newtestpassword"
            };
            var result = bll.ChangePassword(changePasswordModel);
            Assert.AreEqual(true, result);
            result = bll.ChangePassword(changePasswordModel);
            Assert.AreEqual(false, result);
            changePasswordModel = new ChangePasswordModel()
            {
                Login = "testlogin",
                Password = "newtestpassword",
                NewPassword = "testpass"
            };
            result = bll.ChangePassword(changePasswordModel);
            Assert.AreEqual(true, result);
            result = bll.ChangePassword(changePasswordModel);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TestGetRoles()
        {
            var result = bll.GetRoles() as IEnumerable<Role>;
            Assert.AreEqual("Test Role", result.FirstOrDefault(role => role.RoleId==1).Name);
        }

        [TestMethod]
        public void TestGetRoleName()
        {
            var result = bll.GetRoleName(1);
            Assert.AreEqual("Test Role", result);
        }

        [TestMethod]
        public void TestGetRolesForConferenceAndAccount()
        {
            var result = bll.GetRolesForConferenceAndAccount(1, 1) as IEnumerable<Role>;
            Assert.AreEqual(1, result.FirstOrDefault().RoleId);
        }

        [TestMethod]
        public void TestGetConferencesForAccount()
        {
            var result = bll.GetConferencesForAccount(1) as IEnumerable<Conference>;
            Assert.AreEqual(1, result.FirstOrDefault().ConferenceId);
        }
    }
}
