using MVCExamProject.Data;
using MVCExamProject.Models;
using MVCExamProject.Repository.Interfaces;

namespace MVCExamProject.Repository
{
    public class StudentService : IStudentRepository
    {
        private readonly ExamContext context;

        public StudentService(ExamContext context)
        {
            this.context = context;
        }

        public void Delete(User t)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(User t)
        {
            throw new NotImplementedException();
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }
        public int count()
        {
            return context.Users.Where(u => u.IsAdmin == false).Count();
        }
    }
}
