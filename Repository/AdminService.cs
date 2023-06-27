using MVCExamProject.Data;
using MVCExamProject.Models;
using MVCExamProject.Repository.Interfaces;

namespace MVCExamProject.Repository
{
    public class AdminService : IAdminRepository
    {
        private readonly ExamContext context;

        public AdminService(ExamContext context)
        {
            this.context = context;
        }
        public void Delete(User t)
        {
            context.Users.Remove(t);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Insert(User t)
        {
            context.Users.Add(t);
        }

        public void Update(User t)
        {
            context.Users.Update(t);
        }
    }
}
