using Academy.Data.Repositories.DataBase;
using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Academy.Domain.UseCases
{
    public class TaskUseCase
    {
        public List<Task> tasks ;
        public TaskUseCase ()
        { 
            tasks = new List<Task>(); 
        }
        public void GetAllTasksFromModel(ITaskRepository taskRepository)
        {
            tasks = taskRepository.GetAll();
        }
        public void AddTask(string desctiption, string workType, string lesson, string studentLogin, DateTime termin)
        {
            AcademyDB.insertTask(desctiption,workType,lesson,studentLogin,termin);
        }
    }
}
