using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        
        public IRepository<User> UserRepository { get; }
        public IRepository<Instructor> InstructorRepo { get; }
        public IRepository<Student> StudentRepo  { get;}
        public IRepository<CourseStudent> CourseStudentRepo { get; }
        public IRepository<Course> CourseRepo { get;  }
        public IRepository<Exam> ExamRepo { get;  }
        public IRepository<ExamQuestion> ExamQuestionRepo { get;  }

        public IRepository<StudentExam> StudentExamRepo { get;  }
        public IRepository<Question> QuestionRepo { get;  }
        public IRepository<Choice> ChoiceRepo { get;  }
        public IRepository<Answer> AnswerRepo { get; }

        public IRepository<Tasks> TasksRepo { get; }
        public IRepository<TeamMember> TeamMemberRepo { get; }


        Task commit();
    }
}
