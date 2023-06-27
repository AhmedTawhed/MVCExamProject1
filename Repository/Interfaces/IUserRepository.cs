using MVCExamProject.Models;

namespace MVCExamProject.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        bool Find(string username, string password);
        //void create(User user);
        void Save();
        public User GetByUserName(string name);

        public string GetRole(int id);

        public User GetUserByNameAndPassword(string Name, string Password);
    }
}
