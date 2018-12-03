using CMS.BE.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CMS.Core.Interfaces
{
    public interface ITaskCore : IDisposable
    {
        Task<List<TaskDTO>> GetTasksAsync(int conferenceId);
        Task<TaskDTO> GetTaskByIdAsync(int taskId);
        Task<bool> AddTaskAsync(TaskDTO task);
        Task<bool> EditTaskAsync(TaskDTO task);
        Task<bool> DeleteTaskAsync(int taskId);
        Task<List<AccountDTO>> GetAccountsForRoleAsync(string roleName , int conferenceId);
        Task<List<TaskDTO>> GetTasksForEmployeeAsync(int employeeId, int conferenceId);
    }
}