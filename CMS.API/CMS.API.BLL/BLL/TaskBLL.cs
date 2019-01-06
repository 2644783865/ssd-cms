using CMS.API.BLL.Interfaces;
using CMS.API.DAL.Interfaces;
using CMS.API.DAL.Repositories;
using CMS.BE.DTO;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                var task = _repository.GetTaskById(id);
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

        public IEnumerable<TaskDTO> GetTasksByConferenceId(int ConferenceId)
        {
            try
            {
                return _repository.GetTasksByConferenceId(ConferenceId);
            }
            catch
            {
                return null;
            }
        }

        public bool CheckOverlappingTask(int employeeId, DateTime beginDate, DateTime endDate)
        {
            try
            {
                return _repository.CheckOverlappingTask(employeeId, beginDate, endDate);
            }
            catch
            {
                return false;
            }
        }

        public byte[] GetTaskScheduleICal(int employeeId, int conferenceId)
        {
            var entries = GetTasksForEmployee(employeeId, conferenceId).ToList();

            var calendar = new Ical.Net.Calendar();
            foreach (var entry in entries)
            {
                calendar.Events.Add(new CalendarEvent
                {
                    Class = "PUBLIC",
                    Summary = "Task " + entry.Title,
                    Created = new CalDateTime(DateTime.Now),
                    Description = entry.Description,
                    Start = new CalDateTime(Convert.ToDateTime(entry.BeginDate)),
                    End = new CalDateTime(Convert.ToDateTime(entry.EndDate)),
                    Sequence = 0,
                    Uid = Guid.NewGuid().ToString()
                });
            }
            var serializer = new CalendarSerializer(new SerializationContext());
            var serializedCalendar = serializer.SerializeToString(calendar);
            return Encoding.UTF8.GetBytes(serializedCalendar);
        }
    }
}