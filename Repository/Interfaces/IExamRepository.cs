using MVCExamProject.Models;

namespace MVCExamProject.Repository.Interfaces
{
    public interface IExamRepository : IRepository<Exam>
    {
        public int count();
        public Exam getExam(int id);
    }
}
