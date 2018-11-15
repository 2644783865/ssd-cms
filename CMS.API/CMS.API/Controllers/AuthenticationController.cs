using CMS.API.BLL.BLL.Authentication;
using CMS.API.BLL.Models.Authentication;
using System.Web.Http;
using CMS.API.Helpers;
using CMS.API.BLL.Interfaces.Authentication;
using CMS.API.DAL;

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
            if(result > 0) return Ok(result);
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

        // POST: api/Authentication/AddAccount
        [HttpPost]
        [Route("api/authentication/addaccount")]
        public IHttpActionResult AddAccount([FromBody] Account addAccountModel)
        {
            if (string.IsNullOrEmpty(addAccountModel.Name) || string.IsNullOrEmpty(addAccountModel.PhoneNumber)
                || string.IsNullOrEmpty(addAccountModel.Email) || string.IsNullOrEmpty(addAccountModel.Login)) return BadRequest();

            if(_bll.AddAccount(addAccountModel)) return Ok();
            return InternalServerError();  
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

        // GET: api/Authentication/Roles
        [HttpGet]
        [Route("api/authentication/roles")]
        public IHttpActionResult GetRoles()
        {
            return Ok(_bll.GetRoles());
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

        // GET: api/Authentication/Conferencesforaccount?accountId=
        [HttpGet]
        [Route("api/authentication/conferencesforaccount")]
        public IHttpActionResult GetConferencesForAccount(int accountId)
        {
            var conferences = _bll.GetConferencesForAccount(accountId);
            if (conferences == null) return BadRequest();
            return Ok(conferences);
        }

        // POST: api/Authentication/SetRoleForConferenceAndAccount?conferenceId=&login=&roleId=
        [HttpPost]
        [Route("api/authentication/setroleforconferenceandaccount")]
        public IHttpActionResult SetRoleForConferenceAndAccount(int conferenceId, string login, int roleId)
        {
            if (_bll.SetRoleForConferenceAndAccount(conferenceId, login, roleId)) return Ok();
            return BadRequest();
        }

        // POST: api/Authentication/addrole?name=
        [HttpPost]
        [Route("api/authentication/addrole")]
        public IHttpActionResult AddRole(string name)
        {
            if (_bll.AddRole(name)) return Ok();
            return BadRequest();
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
    }
}
