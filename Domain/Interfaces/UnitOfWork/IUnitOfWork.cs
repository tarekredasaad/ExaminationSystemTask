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
        public IRepository<assessment_answers> assessment_AnswersRepo { get; }
        public IRepository<assessment_questions> assessment_QuestionsRepo { get; }
        public IRepository<assessment_questions_relation> assessment_Questions_RelationRepo { get; }
        public IRepository<Assessments> assessmentRepo { get; }
        public IRepository<assessment_options> assessment_optionsRepo { get; }
        public IRepository<assessment_meta> assessment_metaRepo { get; }
        public IRepository<assessment_match> assessment_matchRepo { get; }
        public IRepository<assessment_enrols> assessment_enrolsRepo { get; }
        public IRepository<assessment_data> assessment_dataRepo { get; }
        public IRepository<assessment_department> assessment_departmentRepo { get; }
        public IRepository<assessment_sections> assessment_sectionsRepo { get; }
        public IRepository<assessment_text> assessment_textRepo { get; }
        public IRepository<assessment_true_false> assessment_true_falseRepo { get; }
        public IRepository<Tasks> TasksRepo { get; }
        public IRepository<TeamMember> TeamMemberRepo { get; }


        void commit();
    }
}
