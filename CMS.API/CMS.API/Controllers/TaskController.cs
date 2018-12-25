using CMS.API.BLL.BLL;
using CMS.API.BLL.Interfaces;
using CMS.API.Helpers;
using CMS.BE.DTO;
using CMS.BE.Models;
using System.Web.Http;

namespace CMS.API.Controllers
{
    [BasicAuthentication]
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


        // GET: api/Task/TasksForEmployee?EmployeeId=&ConferenceId=
        [HttpGet]
        [Route("api/task/tasksforempployee")]
        public IHttpActionResult GetTasksForEmployee(int EmployeeId, int ConferenceId)
        {
            var tasks = _bll.GetTasksForEmployee(EmployeeId, ConferenceId);
            if (tasks == null) return BadRequest();
            return Ok(tasks);
        }

        // GET: api/Task/CheckOverlappingTask?EmployeeId=&BeginDate=&EndDate=
        [HttpPost]
        [Route("api/task/checkoverlappingtask")]
        public IHttpActionResult CheckOverlappingTask(int employeeId,[FromBody] DateModel dateModel)
        {
            var tasks = _bll.CheckOverlappingTask(employeeId, dateModel.beginDate, dateModel.endDate);
            return Ok(tasks);
        }
    }
}
