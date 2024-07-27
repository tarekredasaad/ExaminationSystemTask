using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        { }

        //public DbSet<Permission> Permissions { get; set; }
        //public DbSet<User> user { get; set; }
        //public DbSet<Assessments> assessments { get; set; }
        //public DbSet<assessment_answers> assessment_answers { get; set; }
        //public DbSet<assessment_data> assessment_data { get; set; }
        //public DbSet<assessment_department> assessment_department { get; set; }
        //public DbSet<assessment_enrols> assessment_enrols { get; set; }
        //public DbSet<assessment_match> assessment_match { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Group> Groups { get; set; }
        //public DbSet<Tasks> Tasks { get; set; }
        //public DbSet<TeamMember> TeamMembers { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            
        }
    }
}
