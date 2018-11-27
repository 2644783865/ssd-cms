using CMS.API.DAL.Extensions;
using CMS.API.DAL.Interfaces;
using CMS.BE.DTO;
using System.Collections.Generic;

namespace CMS.API.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private cmsEntities _db = new cmsEntities();

        public IEnumerable<TaskDTO> GetTasks()
        {
            return _db.Tasks.Project().To<TaskDTO>();
        }

        public TaskDTO GetTaskById(int id)
        {
            var task = _db.Tasks.Find(id);
            if (task == null) return null;
            else return MapperExtension.mapper.Map<Task, TaskDTO>(task);
        }

        public void AddTask(TaskDTO taskDTO)
        {
            var task = MapperExtension.mapper.Map<TaskDTO, Task>(taskDTO);
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public void EditTask(TaskDTO taskDTO)
        {
            var task = MapperExtension.mapper.Map<TaskDTO, Task>(taskDTO);
            _db.Entry(_db.Tasks.Find(taskDTO.TaskID)).CurrentValues.SetValues(task);
            _db.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            var task = _db.Tasks.Find(taskId);
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
