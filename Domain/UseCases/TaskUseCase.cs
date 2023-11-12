using Academy.Domain.Entities;
using Academy.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Academy.Domain.UseCases
{
    internal class TaskUseCase
    {
        List<Task> tasks ;
        public TaskUseCase ()
        { 
            tasks = new List<Task>(); 
        }
        public void GetAllTsksFromModels(ITaskRepository taskRepository)
        {
            tasks = taskRepository.GetAll();
        }
    }
}
