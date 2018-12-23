using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using CMS.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.API.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private cmsEntities _db = new cmsEntities();
        private ITaskRepository _repository = new TaskRepository();

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
            _db.Entry(_db.Tasks.Find(taskDTO.TaskID)).CurrentValues.SetValues(task);
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

        public bool CheckTasks(int employeeId, DateTime beginDate, DateTime endDate)
        {
            // return false, when no overlapping
            // return true, when overlapping with task
            IEnumerable<TaskDTO> taskLis = GetTasks(employeeId);
            foreach (TaskDTO task in taskLis)
            {
                if (task.BeginDate < beginDate && task.EndDate < beginDate)
                {
                    return false;
                }
                else if (task.BeginDate > beginDate && task.EndDate > endDate)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckOverlappingTask(int employeeId, DateTime beginDate, DateTime endDate)
        {
            Response res = new Response();
            try
            {
               bool resEve = _repository.CheckTasks(employeeId, beginDate, endDate);

                if (resEve == true)
                {
                    res.Message = "Overlapping with other task";
                    res.Status = true;
                }
                else
                {
                    res.Message = "";
                    res.Status = false;
                }
            }
            catch
            {
                return false;
            }
            return res.Status;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
