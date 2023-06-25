using MVCExamProject.Data;
using MVCExamProject.Models;

namespace MVCExamProject.Repository
{
    public class QuestionOptionService : IRepository<QuestionOption>
    {
        private readonly ExamContext context;

        public QuestionOptionService(ExamContext context)
        {
            this.context = context;
        }
        public void Delete(QuestionOption t)
        {
            context.QuestionOptions.Remove(t);
        }

        public List<QuestionOption> GetAll()
        {
            return context.QuestionOptions.ToList();
        }

        public QuestionOption GetById(int id)
        {
            return context.QuestionOptions.FirstOrDefault(q => q.Id == id);
        }

        public void Insert(QuestionOption t)
        {
            context.QuestionOptions.Add(t);
        }

        public void Update(QuestionOption t)
        {
            context.QuestionOptions.Update(t);
        }
    }
}
