using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.BLL.Interfaces
{
        public interface ITaskBLL
        { 
           IEnumerable<TaskDTO> GetTasks(int ConferenceId);
            TaskDTO GetTaskById(int id);
            bool AddTask(TaskDTO task);
            bool EditTask(TaskDTO task);
            bool DeleteTask(int TaskId);
           IEnumerable<AccountDTO> GetAccountsForRole(string roleName, int conferenceId);
           IEnumerable<TaskDTO> GetTasksForEmployee(int EmployeeId, int ConferenceId);
    }
}

