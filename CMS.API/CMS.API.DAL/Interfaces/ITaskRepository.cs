using CMS.BE.DTO;
using System;
using System.Collections.Generic;

namespace CMS.API.DAL.Interfaces
{
    public interface ITaskRepository : IDisposable
    {
        IEnumerable<TaskDTO> GetTasks(int conferenceId);
        TaskDTO GetTaskById(int id);
        void AddTask(TaskDTO taskDTO);
        void EditTask(TaskDTO taskDTO);
        void DeleteTask(int taskId);
        IEnumerable<TaskDTO> GetTasksForEmployee(int employeeId, int conferenceId);
    }
}