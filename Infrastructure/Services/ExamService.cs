using AutoMapper;
using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        ICourseService courseService;

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, ICourseService courseService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            this.courseService = courseService;
           
        }

        public async Task<ResultDTO> AddExam(AddExamDTO examDTO)
        {
            if (examDTO != null)
            {
                Exam exam = new Exam();
                string userName = _httpContextAccessor.HttpContext.Session.GetString("Username");
                Instructor member = _unitOfWork.InstructorRepo.Get(x => x.username == userName);
                exam = _mapper.Map<Exam>(examDTO.ExamDTO);
                
                exam.InstructorId = member.id;
                
               
                //NewExam.Questions = examDTO.questions;
                List<Question> questionList = new List<Question>();
                List<ExamQuestion> examQuestions = new List<ExamQuestion>();
                //_unitOfWork.commit();
                foreach (var _question in examDTO.questions)
                {
                List<Choice> choices = new List<Choice>();

                    Question question = new Question();
                    question = _mapper.Map<Question>(_question);
                    question.ExamId = exam.id;
                    //var newQuestion =await _unitOfWork.QuestionRepo.Create(question);
                    //_unitOfWork.commit();

                    ExamQuestion examQuestion = new ExamQuestion();
                    examQuestion.Question = question;
                    examQuestion.Exam = exam;
                    examQuestions.Add(examQuestion);
                    //examQuestion =await _unitOfWork.ExamQuestionRepo.Create(examQuestion);
                    //_unitOfWork.commit();

                    foreach (var _choice in _question.Choices)
                    {
                        Choice choice = new Choice();
                        choice = _mapper.Map<Choice>(_choice);
                        choice.questionId = question.id;
                        choices.Add(choice);
                        question.Choices = choices;
                        //choice = await _unitOfWork.ChoiceRepo.Create(choice);
                    }
                    questionList.Add(question);
                  
                }
                exam.Questions = questionList;
                var NewExam = await _unitOfWork.ExamRepo.Create(exam);

                await _unitOfWork.ExamQuestionRepo.AddRange(examQuestions);

                return new ResultDTO() { StatusCode = 200, Data = NewExam, Message = "You added the Task successfully" };


            }
            else
            {
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };

            }
        }
        public async Task<ResultDTO> AddExamBySystem()
        {
            
                string userName = _httpContextAccessor.HttpContext.Session.GetString("Username");
                Instructor member = _unitOfWork.InstructorRepo.Get(x => x.username == userName);
                List<Course> courses = (List<Course>)_unitOfWork.CourseRepo.GetAll(c => c.InstructorId == member.id).ToList();
            Course[] ArrayCourses = courses.ToArray();
                Random random = new Random();

                int randomIndex = random.Next(0,ArrayCourses.Length);
            int RandomNumerQuestion = random.Next(3, 9);
            int courseID = ArrayCourses[randomIndex].id;
                //Course course = new Course();
                //course = _unitOfWork.CourseRepo.Get(c => c.id == courseID);
                Exam exam = new Exam();
                exam.CourseId = courseID;
                exam.title = ArrayCourses[randomIndex].title + "quiz";
                exam.InstructorId = member.id;
                exam.NumberQuestions = RandomNumerQuestion;
                exam.type = TypeExam.Quiz;
                exam.Score = exam.NumberQuestions * 10;

                await  _unitOfWork.commit();

            Level[] levels =(Level[]) Enum.GetValues(typeof(Level));
                List<Question> questionList = new List<Question>();
                List<ExamQuestion> examQuestions = new List<ExamQuestion>();

                for(int i =0;i< exam.NumberQuestions; i++)
                {
                List<Choice> choices = new List<Choice>();
                    Question question = new Question();
                    question.grade = 10;
                    question.ExamId = exam.id;
                    question.Level = levels[i];
                    question.text = $" Question { i + 1} ";
                    //question = await _unitOfWork.QuestionRepo.Create(question);
                    // _unitOfWork.commit();

                    ExamQuestion examQuestion = new ExamQuestion();
                    examQuestion.Question = question;
                    examQuestion.Exam = exam;
                    examQuestions.Add(examQuestion);
                    //examQuestion = await _unitOfWork.ExamQuestionRepo.Create(examQuestion);
                    //_unitOfWork.commit();

                    Choice choice = new Choice();
                    choice.questionId = question.id;
                    choice.IsRight = true;
                    choice.text = $"choice {i * 2 + 1}"; 
                    choices.Add(choice);
                    //choice = await _unitOfWork.ChoiceRepo.Create(choice);
                    //_unitOfWork.commit();

                    Choice choice2 = new Choice();
                    choice2.questionId = question.id;
                    choice2.IsRight = true;
                    choice2.text = $"choice {i * 2 + 2}";
                      choices.Add(choice2);
                    question.Choices = choices;
                    questionList.Add(question);
                    //choice2 = await _unitOfWork.ChoiceRepo.Create(choice2);
                    //_unitOfWork.commit();
                }
                exam.Questions = questionList;
                var NewExam = await _unitOfWork.ExamRepo.Create(exam);
            //await _unitOfWork.ExamRepo.Update(exam);



            await _unitOfWork.ExamQuestionRepo.AddRange(examQuestions);



            return ResultDTO.Sucess(NewExam);


            

            
        }

        public async Task<ResultDTO> GetExams()
        {
            string userName = _httpContextAccessor.HttpContext.Session.GetString("Username");
            Instructor member = _unitOfWork.InstructorRepo.Get(x => x.username == userName);

            List<Exam> exams = (List<Exam>) _unitOfWork.ExamRepo.GetAll(e=>e.InstructorId == member.id).ToList();

            return ResultDTO.Sucess(exams);
        }
        public async Task<ResultDTO> AssignStudentToExam(AssignStudentDTO assignStudentDTO)
        {
            if(assignStudentDTO != null)
            {

                string userName = _httpContextAccessor.HttpContext.Session.GetString("Username");
                Instructor member = _unitOfWork.InstructorRepo.Get(x => x.username == userName);
                Student student = _unitOfWork.StudentRepo.Get(s => s.id == assignStudentDTO.StudentId);

                Exam exam = _unitOfWork.ExamRepo.Get(e => e.InstructorId == member.id && e.id == assignStudentDTO.ExamID);
                StudentExam studentExam = new StudentExam();
                studentExam = _unitOfWork.StudentExamRepo.Get(st=>st.ExamId == exam.id && st.StudentId == assignStudentDTO.StudentId);
               
                if (studentExam != null && !studentExam.IsAssigned) 
                { 
                    studentExam.IsAssigned = true;

                    await  _unitOfWork.StudentExamRepo.Update(studentExam);

                    return ResultDTO.Sucess(studentExam);
                }

            }

            return ResultDTO.Faliure();

        }
        public async Task<ResultDTO> TakeExam(TakeExamDTO takeExamDTO)
        {
            if(takeExamDTO != null)
            {
                //CourseStudent CourseStudnet = await this.courseService.GetStudentCourse(takeExamDTO);
                string UserName = _httpContextAccessor.HttpContext.Session.GetString("Username");
                Student student = _unitOfWork.StudentRepo.Get(s=>s.username == UserName);
                Course course = _unitOfWork.CourseRepo.Get(c => c.id == takeExamDTO.CourseId);
                if (course != null && student != null)
                {
                    bool IsStudentJoinCourse = _unitOfWork.CourseStudentRepo.GetAll().Any(sc => sc.CourseId == course.id && sc.StudentId == student.id);
                    if (IsStudentJoinCourse)
                    {
                        Exam exam = _unitOfWork.ExamRepo.Get(e=>e.title == takeExamDTO.ExamTitle);
                        if(exam != null)
                        {
                            
                            StudentExam studentExam =_unitOfWork.StudentExamRepo.Get(e=>e.StudentId == student.id && e.ExamId == exam.id);
                            if(studentExam != null)
                            {
                                if (studentExam.IsTaken && exam.type == TypeExam.Final)
                                {
                                    return new ResultDTO() { StatusCode = 400, Data = studentExam ,Message = "you can't take  exam agian" };
                                }
                                studentExam.IsTaken = true;

                                _unitOfWork.StudentExamRepo.Update(studentExam);
                                return new ResultDTO() { StatusCode = 200, Data = studentExam, Message = "you have taken quize successfully" };
                            }
                            StudentExam StudentExam = new StudentExam();
                            StudentExam.ExamId = exam.id;
                            StudentExam.StudentId = student.id;
                            StudentExam.IsTaken = true;
                            StudentExam.Completed = false;
                            StudentExam.Exam = exam;
                            StudentExam.Student = student;
                            StudentExam = await _unitOfWork.StudentExamRepo.Create(StudentExam);
                            var result = ResultDTO.Sucess(StudentExam);

                            return result; //new ResultDTO() { StatusCode = 200, Data = StudentExam, Message = "you have taken quize successfully" };

                        }

                        //return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
                    }
                    //return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
                }
                //return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
            }
            
                return new ResultDTO() { StatusCode = 400, Data = "Invalid operation" };
           
        }

        public async Task<ResultDTO> ViewResult(ExamResultDTO examResultDTO)
        {
            if(examResultDTO != null)
            {
                string UserName = _httpContextAccessor.HttpContext.Session.GetString("Username");
                Student student = _unitOfWork.StudentRepo.Get(s => s.username == UserName);
                StudentExam studentExam = new StudentExam();
                studentExam = _unitOfWork.StudentExamRepo.Get(s => s.ExamId == examResultDTO.ExamId && s.StudentId == student.id);
                if(studentExam != null && studentExam.Completed)
                {
                    var result = ResultDTO.Sucess(studentExam); 
                    return result;
                }
                string UserNameInstructor = _httpContextAccessor.HttpContext.Session.GetString("Username");
                Instructor instructor = _unitOfWork.InstructorRepo.Get(s => s.username == UserNameInstructor);
                List<Student> students = new List<Student>();
                

                students = _unitOfWork.ExamRepo.Get(s => s.id == examResultDTO.ExamId, "Students").Students;
               
                return ResultDTO.Sucess(studentExam); 
            }
            // var result = ResultDTO.Faliure();
            return ResultDTO.Faliure(); 
        }
    }
}
