using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
        public interface ITaskBLL
        { 
           IEnumerable<TaskDTO> GetTasks();
            TaskDTO GetTaskById(int id);
            bool AddTask(TaskDTO task);
            bool EditTask(TaskDTO task);
            bool DeleteTask(int taskId);
        }
    }

