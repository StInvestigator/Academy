using Academy.Data.Models;
using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using Academy.Presentation.Pages.Student;
using Academy.Presentation.Pages.Teacher;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Academy.Data.Repositories
{
    public  class TaskRepository : ITaskRepository
    {
        List<TaskModel> _tasks;
        public TaskRepository()
        {
            _tasks = new List<TaskModel>();

            foreach (var item in AcademyDB.GetTasks())
            {
                _tasks.Add(item);
            }
        }

        public List<Task> GetAll()
        {
            List<Task> tasks = new List<Task>();
            foreach (var item in _tasks)
            {
                tasks.Add(new Task(
                    item.Description ?? "Description",
                    item.Type ?? "Type",
                    item.Lesson ?? "Lesson",
                    item.Termin ?? DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                    item.StudentLogin ?? "SLogin",
                    item.isDone ?? false
                    ));
            }
            return tasks;
        }
    }
}
