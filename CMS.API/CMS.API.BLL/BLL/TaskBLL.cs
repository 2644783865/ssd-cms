using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.BLL
{
    public class TaskBLL : ITaskBLL
    {
        private ITaskRepository _repository = new TaskRepository();

        public IEnumerable<TaskDTO> GetTasks(int ConferenceId)
        {
            try
            {
                return _repository.GetTasks(ConferenceId);
            }
            catch
            {
                return null;
            }
        }
        public TaskDTO GetTaskById(int id)
        {
            try
            {
                var task = GetTaskById(id);
                if (task == null) return null;
                return task;
            }
            catch
            {
                return null;
            }
        }
        public bool AddTask(TaskDTO task)
        {
            try
            {
                _repository.AddTask(task);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditTask(TaskDTO task)
        {
            try
            {
                _repository.EditTask(task);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool DeleteTask(int taskId)
        {
            try
            {
                _repository.DeleteTask(taskId);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public IEnumerable<TaskDTO> GetTasksForEmployee(int EmployeeID, int ConferenceId)
        {
            try
            {
                return _repository.GetTasksForEmployee(EmployeeID, ConferenceId);
            }
            catch
            {
                return null;
            }
        }
    }
}