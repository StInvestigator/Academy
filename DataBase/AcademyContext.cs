using Academy.Core.Constants;
using Academy.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Academy.DataBase
{
    public class AcademyContext : DbContext
    {
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Domain.Entities.Task> Tasks { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-OF66R01\SQLEXPRESS;Initial Catalog=FinalAcademy;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
