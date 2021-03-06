﻿using CMS.BE.DTO;
using CMS.BE.Models;
using CMS.Core.Helpers;
using CMS.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Core.Core
{
    public class TaskCore : ITaskCore
    {
        private ApiHelper _apiHelper = new ApiHelper();

        public async Task<List<TaskDTO>> GetTasksAsync(int ConferenceId)
        {
            var path = $"{Properties.Resources.getTasksPath}?conferenceId={ConferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<TaskDTO>>(result.Content);
            }
            return null;
        }

        public async Task<TaskDTO> GetTaskByIdAsync(int TaskID)
        {
            var path = $"{Properties.Resources.getTaskByIdPath}?taskId={TaskID}";
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

        public async Task<bool> DeleteTaskAsync(int TaskID)
        {
            var path = $"{Properties.Resources.deleteTaskPath}?taskId={TaskID}";
            var result = await _apiHelper.Delete(path);
            return result != null && result.ResponseType == ResponseType.Success;
        }
        public async Task<List<AccountDTO>> GetAccountsForConferenceEmployeeAsync(int ConferenceId)
        {
            var path = $"{Properties.Resources.getAccountsForRolePath}?roleName={Properties.RolesResources.ConferenceStaffMember}&conferenceId={ConferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<AccountDTO>>(result.Content);
            }
            return null;
        }
        public async Task<List<TaskDTO>> GetTasksForEmployeeAsync(int EmployeeId, int ConferenceId)
        {
            var path = $"{Properties.Resources.getTasksForEmployeePath}?employeeId={EmployeeId}&conferenceId={ConferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<List<TaskDTO>>(result.Content);
            }
            return null;
        }

        public async Task<bool> CheckOverlappingTaskAsync(int EmployeeId, DateTime beginDate, DateTime endDate, int taskId)
        {
            var dateModel = new DateModel()
            {
                beginDate = beginDate,
                endDate = endDate
            };
            var path = $"{Properties.Resources.checkOvelappingTaskPath}?employeeId={EmployeeId}&taskId={taskId}";
            var result = await _apiHelper.Post(path, dateModel);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<bool>(result.Content);
            }
            return false;
        }

        public async Task<byte[]> GetTaskScheduleICalAsync(int employeeId, int conferenceId)
        {
            var path = $"{Properties.Resources.getTaskScheduleICalPath}?employeeId={employeeId}&conferenceId={conferenceId}";
            var result = await _apiHelper.Get(path);
            if (result != null && result.ResponseType == ResponseType.Success)
            {
                return JsonConvert.DeserializeObject<ByteArray>(result.Content).Content;
            }
            return null;
        }
        public void Dispose() => _apiHelper.Dispose();
    }
}