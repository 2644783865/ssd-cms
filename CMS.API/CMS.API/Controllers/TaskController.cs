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
        public IHttpActionResult GetTasks(int conferenceId)
        {
            return Ok(_bll.GetTasks());
        }



        // GET: api/Task/TaskById?TaskId=
        [HttpGet]
        [Route("api/task/taskbyid")]
        public IHttpActionResult GetTaskById(int taskId)
        {
            var task = _bll.GetTaskById(taskId);
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
    }
}
