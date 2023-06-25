using MVCExamProject.Data;
using MVCExamProject.Models;

namespace MVCExamProject.Repository
{
    public class UserExamService : IRepository<UserExam>
    {
        private readonly ExamContext context;

        public UserExamService(ExamContext context)
        {
            this.context = context;
        }

        public void Delete(UserExam t)
        {
            context.UserExams.Remove(t);
        }

        public List<UserExam> GetAll()
        {
            return context.UserExams.ToList();
        }

        public UserExam GetById(int id)
        {
            return context.UserExams.FirstOrDefault(u => u.Id == id);
        }

        public void Insert(UserExam t)
        {
            context.UserExams.Add(t);
        }

        public void Update(UserExam t)
        {
            context.UserExams.Update(t);
        }
    }
}
