using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CMS.Core.Interfaces
{
    public interface ITaskCore : IDisposable
    {
        Task<List<TaskDTO>> GetTasksAsync(int ConferenceId);
        Task<TaskDTO> GetTaskByIdAsync(int TaskID);
        Task<bool> AddTaskAsync(TaskDTO task);
        Task<bool> EditTaskAsync(TaskDTO task);
        Task<bool> DeleteTaskAsync(int TaskID);
        Task<List<AccountDTO>> GetAccountsForRoleAsync(string roleName , int ConferenceId);
        Task<List<TaskDTO>> GetTasksForEmployeeAsync(int EmployeeId, int ConferenceId);
    }
}