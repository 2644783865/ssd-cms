using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<TaskDTO> GetTasks(int conferenceId)
        {
            return _db.Tasks.Where(task => task.ConferenceId == conferenceId).Project().To<TaskDTO>();
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
            _db.Entry(_db.Tasks.Find(taskDTO.TaskId)).CurrentValues.SetValues(task);
            _db.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            var task = _db.Tasks.Find(taskId);
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }

        public IEnumerable<TaskDTO> GetTasksForEmployee(int EmployeeId, int ConferenceId)
        {
            return _db.Tasks.Where(task => task.EmployeeId == EmployeeId && task.ConferenceId == ConferenceId)
                .Distinct().Project().To<TaskDTO>();
        }

        public IEnumerable<TaskDTO> GetTasksByConferenceId(int ConferenceId)
        {
            return _db.Tasks.Where(task => task.ConferenceId == ConferenceId)
                .Distinct().Project().To<TaskDTO>();
        }

        public bool CheckOverlappingTask(int employeeId, DateTime beginDate, DateTime endDate)
        {
            return _db.Tasks.Where(t => (t.BeginDate <= beginDate && t.EndDate >= beginDate) 
            || (t.BeginDate <= endDate && t.EndDate >= endDate)).Count() == 0;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
