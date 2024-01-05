using Academy.Data.Models;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using Academy.Presentation.Pages.Student;
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
            // HardCode data 
            _tasks.Add(new TaskModel("Writee a 10 sentences in English","HT","English", DateOnly.FromDateTime(DateTime.Now.AddDays(2)),"student",false));
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
