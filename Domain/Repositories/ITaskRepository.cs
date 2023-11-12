﻿using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Domain.Repositories
{
    public interface ITaskRepository
    {
        public List<Task> GetAll();
    }
}
