using CMS.API.BLL.BLL;
using System.Web.Http;
using CMS.API.Helpers;
using CMS.API.BLL.Interfaces;
using CMS.BE.Models.Authentication;
using CMS.BE.DTO;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
    public class AuthenticationController : ApiController
    {
        private IAuthenticationBLL _bll = new AuthenticationBLL();

        // POST: api/Authentication/Login
        [HttpPost]
        [Route("api/authentication/login")]
        public IHttpActionResult Login([FromBody] LoginModel loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.Login) || string.IsNullOrEmpty(loginModel.Password))
                return BadRequest();
            var result = _bll.Login(loginModel);
            if(result != null) return Ok(result);
            return Unauthorized();
        }

        // POST: api/Authentication/CheckCredentials
        [HttpPost]
        [Route("api/authentication/checkcredentials")]
        public IHttpActionResult CheckCredentials([FromBody] LoginModel loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.Login) || string.IsNullOrEmpty(loginModel.Password))
                return BadRequest();
            if (_bll.CheckCredentials(loginModel)) return Ok();
            return Unauthorized();
        }

        // POST: api/Authentication/ChangePassword
        [HttpPost]
        [Route("api/authentication/changepassword")]
        public IHttpActionResult ChangePassword([FromBody] ChangePasswordModel changePasswordModel)
        {
            if (string.IsNullOrEmpty(changePasswordModel.Login) 
                || string.IsNullOrEmpty(changePasswordModel.Password)
                || string.IsNullOrEmpty(changePasswordModel.NewPassword)) return BadRequest();
            if (_bll.ChangePassword(changePasswordModel)) return Ok();
            return Unauthorized();
        }

        // GET: api/Authentication/AccountById?accountId=
        [HttpGet]
        [Route("api/authentication/accountbyid")]
        public IHttpActionResult GetAccountById(int accountId)
        {
            var account = _bll.GetAccountById(accountId);
            if (account == null) return BadRequest();
            return Ok(account);
        }

        // GET: api/Authentication/AccountByLogin?login=
        [HttpGet]
        [Route("api/authentication/accountbylogin")]
        public IHttpActionResult GetAccountByLogin(string login)
        {
            var account = _bll.GetAccountByLogin(login);
            if (account == null) return BadRequest();
            return Ok(account);
        }
        
        // POST: api/Authentication/AddAccount
        [HttpPost]
        [Route("api/authentication/addaccount")]
        public IHttpActionResult AddAccount([FromBody] AccountDTO account)
        {
            if (string.IsNullOrEmpty(account.Name) || string.IsNullOrEmpty(account.PhoneNumber)
                || string.IsNullOrEmpty(account.Email) || string.IsNullOrEmpty(account.Login)) return BadRequest();

            if(_bll.AddAccount(account)) return Ok();
            return InternalServerError();  
        }

        // PUT: api/Authentication/EditAccount
        [HttpPut]
        [Route("api/authentication/editaccount")]
        public IHttpActionResult EditAccount([FromBody] AccountDTO account)
        {
            if (string.IsNullOrEmpty(account.Name) || string.IsNullOrEmpty(account.PhoneNumber)
                || string.IsNullOrEmpty(account.Email) || string.IsNullOrEmpty(account.Login)) return BadRequest();

            if (_bll.EditAccount(account)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Authentication/DeleteAccount?accountId=
        [HttpDelete]
        [Route("api/authentication/deleteaccount")]
        public IHttpActionResult DeleteAccount(int accountId)
        {
            if (_bll.DeleteAccount(accountId)) return Ok();
            return InternalServerError();
        }


        // GET: api/Authentication/Roles
        [HttpGet]
        [Route("api/authentication/roles")]
        public IHttpActionResult GetRoles()
        {
            return Ok(_bll.GetRoles());
        }

        // GET: api/Authentication/HRRoles
        [HttpGet]
        [Route("api/authentication/hrroles")]
        public IHttpActionResult GetHRRoles()
        {
            return Ok(_bll.GetHRRoles());
        }

        // GET: api/Authentication/Rolename?roleId=
        [HttpGet]
        [Route("api/authentication/rolename")]
        public IHttpActionResult GetRoleName(int roleId)
        {
            var name = _bll.GetRoleName(roleId);
            if (name == null) return BadRequest();
            return Ok(name);
        }

        // GET: api/Authentication/Rolesforconferenceandaccount?conferenceId=&accountId=
        [HttpGet]
        [Route("api/authentication/rolesforconferenceandaccount")]
        public IHttpActionResult GetRolesForConferenceAndAccount(int conferenceId, int accountId)
        {
            var roles = _bll.GetRolesForConferenceAndAccount(conferenceId, accountId);
            if (roles == null) return BadRequest();
            return Ok(roles);
        }

        // POST: api/Authentication/addrole?name=
        [HttpPost]
        [Route("api/authentication/addrole")]
        public IHttpActionResult AddRole(string name)
        {
            if (_bll.AddRole(name)) return Ok();
            return BadRequest();
        }

        // POST: api/Authentication/SetRoleForConferenceAndAccount?conferenceId=&login=&roleId=
        [HttpPost]
        [Route("api/authentication/setroleforconferenceandaccount")]
        public IHttpActionResult SetRoleForConferenceAndAccount(int conferenceId, string login, int roleId)
        {
            if (_bll.SetRoleForConferenceAndAccount(conferenceId, login, roleId)) return Ok();
            return BadRequest();
        }

        // DELETE: api/Authentication/DeleteRoleForConferenceAndAccount?conferenceId=&login=&roleId=
        [HttpDelete]
        [Route("api/authentication/deleteroleforconferenceandaccount")]
        public IHttpActionResult DeleteRoleForConferenceAccount(int conferenceId, string login, int roleId)
        {
            if (_bll.DeleteAssignmentRoleForConferenceAndAccount(conferenceId, login, roleId)) return Ok();
            return InternalServerError();
        }

        // GET: api/Authentication/AccountsForRole?roleName=&conferenceId=
        [HttpGet]
        [Route("api/authentication/accountsforrole")]
        public IHttpActionResult GetAccountsForRole(string roleName, int conferenceId)
        {
            var accounts = _bll.GetAccountsForRole(roleName, conferenceId);
            if (accounts == null) return BadRequest();
            return Ok(accounts);
        }


        // GET: api/Authentication/ConferencesForAccount?accountId=
        [HttpGet]
        [Route("api/authentication/conferencesforaccount")]
        public IHttpActionResult GetConferencesForAccount(int accountId)
        {
            var conferences = _bll.GetConferencesForAccount(accountId);
            if (conferences == null) return BadRequest();
            return Ok(conferences);
        }
    }
}
