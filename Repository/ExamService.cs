using MVCExamProject.Data;
using MVCExamProject.Models;

namespace MVCExamProject.Repository
{
    public class ExamService : IRepository<Exam>
    {
        private readonly ExamContext context;

        public ExamService(ExamContext context)
        {
            this.context = context;
        }
        public void Delete(Exam t)
        {
            context.Exams.Remove(t);
        }

        public List<Exam> GetAll()
        {
            return context.Exams.ToList();
        }

        public Exam GetById(int id)
        {
            return context.Exams.FirstOrDefault(u => u.Id == id);
        }

        public void Insert(Exam t)
        {
            context.Exams.Add(t);
        }

        public void Update(Exam t)
        {
            context.Exams.Update(t);
        }
    }
}
