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
        //public DbSet<assessment_meta> assessment_meta { get; set; }
        //public DbSet<assessment_options> assessment_options { get; set; }
        //public DbSet<assessment_questions> assessment_questions { get; set; }
        //public DbSet<assessment_questions_relation> assessment_questions_relation { get; set; }
        //public DbSet<assessment_sections> assessment_sections { get; set; }
        //public DbSet<assessment_text> assessment_text { get; set; }
        //public DbSet<assessment_true_false> assessment_true_false { get; set; }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            
        }
    }
}
