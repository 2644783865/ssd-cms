using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using System;
using System.Web.Http;

namespace CMS.API.Controllers
{
    public class TaskController : ApiController
    {
        private ITaskBLL _bll = new TaskBLL();

        // GET: api/Task/Tasks?ConferenceId=
        [HttpGet]
        [Route("api/task/tasks")]
        public IHttpActionResult GetTasks(int ConferenceId)
        {
            return Ok(_bll.GetTasks(ConferenceId));
        }



        // GET: api/Task/TaskById?TaskId=
        [HttpGet]
        [Route("api/task/taskbyid")]
        public IHttpActionResult GetTaskById(int TaskID)
        {
            var task = _bll.GetTaskById(TaskID);
            if (task == null) return BadRequest();
            return Ok(task);
        }

        // POST: api/Task/AddTask
        [HttpPost]
        [Route("api/task/addtask")]
        public IHttpActionResult AddTask([FromBody] TaskDTO task)
        {
            if (_bll.AddTask(task)) return Ok();
            return InternalServerError();
        }

        // PUT: api/Task/EditTask
        [HttpPut]
        [Route("api/task/edittask")]
        public IHttpActionResult EditTask([FromBody] TaskDTO task)
        {
            if (_bll.EditTask(task)) return Ok();
            return InternalServerError();
        }

        // DELETE: api/Task/DeleteTask?TaskId=
        [HttpDelete]
        [Route("api/task/deletetask")]
        public IHttpActionResult DeleteTask(int taskId)
        {
            if (_bll.DeleteTask(taskId)) return Ok();
            return InternalServerError();
        }


        // GET: api/Authentication/AccountsForRole?roleName=&conferenceId=
        [HttpGet]
        [Route("api/authentication/accountsforrole")]
        public IHttpActionResult GetAccountsForRole(string roleName, int ConferenceId)
        {
            var accounts = _bll.GetAccountsForRole(roleName, ConferenceId);
            if (accounts == null) return BadRequest();
            return Ok(accounts);
        }



        // GET: api/Task/TasksForEmployee?EmployeeId=&ConferenceId=
        [HttpGet]
        [Route("api/authentication/accountsforrole")]
        public IHttpActionResult GetTasksForRole(int EmployeeId, int ConferenceId)
        {
            var tasks = _bll.GetTasksForEmployee(EmployeeId, ConferenceId);
            if (tasks == null) return BadRequest();
            return Ok(tasks);
        }
    }
}
