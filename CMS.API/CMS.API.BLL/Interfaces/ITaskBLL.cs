﻿using CMS.BE.DTO;
using System;
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
        IEnumerable<TaskDTO> GetTasksForEmployee(int EmployeeId, int ConferenceId);
        IEnumerable<TaskDTO> GetTasksByConferenceId(int ConferenceId);
        bool CheckOverlappingTask(int employeeId, DateTime beginDate, DateTime endDate, int taskId);
        byte[] GetTaskScheduleICal(int employeeId, int conferenceId);
    }   
}

