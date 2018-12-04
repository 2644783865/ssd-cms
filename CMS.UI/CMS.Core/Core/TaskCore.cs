using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class TaskCore : ITaskCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<TaskDTO>> GetTasksAsync(int conferenceId)
        {
            var path = $"{Properties.Resources.getTasksPath}?conferenceId={conferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<TaskDTO>>(result.Content);
            }
            return null;
        }

        public async Task<TaskDTO> GetTaskByIdAsync(int taskId)
        {
            var path = $"{Properties.Resources.getTaskByIdPath}?taskId={taskId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<TaskDTO>(result.Content);
            }
            else return null;
        }

        public async Task<bool> AddTaskAsync(TaskDTO task)
        {
            var path = Properties.Resources.addTaskPath;
            var result = await _apiHelper.Post(path, task);
            return result != null && result.ResponseType == ResponseType.Success;
        }
        public async Task<bool> EditTaskAsync(TaskDTO task)
        {
            var path = Properties.Resources.editTaskPath;
            var result = await _apiHelper.Put(path, task);
            return result != null && result.ResponseType == ResponseType.Success;
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var path = $"{Properties.Resources.deleteTaskPath}?taskId={taskId}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }
        public async Task<List<AccountDTO>> GetAccountsForRoleAsync(string roleName, int conferenceId)
        {
            var path = $"{Properties.Resources.getAccountsForRolePath}?roleName={Properties.RolesResources.ConferenceStaffMember}&conferenceId={conferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<AccountDTO>>(result.Content);
            }
            return null;
        }
        public async Task<List<TaskDTO>> GetTasksForEmployeeAsync(int employeeId, int conferenceId)
        {
            var path = $"{Properties.Resources.getTasksForEmployeePath}?employeeId={employeeId}&conferenceId={conferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<TaskDTO>>(result.Content);
            }
            return null;
        }
        public void Dispose() => _apiHelper.Dispose();
    }
}