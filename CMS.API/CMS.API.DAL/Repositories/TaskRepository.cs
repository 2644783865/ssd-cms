using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<TaskDTO> GetTasks(int conferenceId)
        {
            return _db.Tasks.Project().To<TaskDTO>();
        }

        public TaskDTO GetTaskById(int id)
        {
            var task = _db.Tasks.Find(id);
            if (task == null) return null;
            else return MapperExtension.mapper.Map<Task, TaskDTO>(task);
        }

        public void AddTask(TaskDTO taskDTO)
        {
            var task = MapperExtension.mapper.Map<TaskDTO, Task>(taskDTO);
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public void EditTask(TaskDTO taskDTO)
        {
            var task = MapperExtension.mapper.Map<TaskDTO, Task>(taskDTO);
            _db.Entry(_db.Tasks.Find(taskDTO.TaskID)).CurrentValues.SetValues(task);
            _db.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            var task = _db.Tasks.Find(taskId);
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }
        public IEnumerable<AccountDTO> GetAccountsForRole(string roleName, int ConferenceId)
        {
            var selectedAccounts = _db.Accounts.Where(account =>
            account.ConferenceStaffs.Where(cs => cs.Role.Name.Equals(roleName) && cs.ConferenceId == ConferenceId).Count() != 0);
            var result = selectedAccounts.Project().To<AccountDTO>();
            return result.ToList();
        }
        public IEnumerable<TaskDTO> GetTasksForEmployee(int EmployeeId, int ConferenceId)
        {
            return _db.Tasks.Where(task => task.EmployeeId == EmployeeId && task.ConferenceId == ConferenceId)
                .Select(task => task.TaskId).Distinct().Project().To<TaskDTO>();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
